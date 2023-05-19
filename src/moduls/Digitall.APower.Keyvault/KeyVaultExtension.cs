using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Dgt.APower.Http;
using Digitall.APower.EnvironmentVariables;
using Digitall.APower.Keyvault.Contracts;
using Microsoft.Xrm.Sdk;

namespace Digitall.APower.Keyvault
{
    public static class KeyVaultExtension
    {
        private const int Timeout = 15000;

        //https://docs.microsoft.com/de-de/powerapps/developer/common-data-service/best-practices/business-logic/set-keepalive-false-interacting-external-hosts-plugin
        //by default, Lazy objects are thread-safe.
        private static readonly Lazy<HttpClient> Lazy = new Lazy<HttpClient>(() =>
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(Timeout)
            };
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        });

        private static HttpClient HttpClient => Lazy.Value;

        public static string KeyVaultSecret(this Executor executor, string url) => executor.Core.KeyVaultSecret(url);

        //GET {vaultBaseUrl}/secrets/{secret-name}/{secret-version}?api-version=7.0
        public static string KeyVaultSecret(this PluginCore executor, string url)
        {
            const string accessTokenCacheKey = "KeyVault.AccessToken";

            if (executor.CacheService.TryGet(url, out var value))
            {
                return (string)value;
            }

            if (!executor.CacheService.TryGet(accessTokenCacheKey, out var accessToken)) //call on-demand
            {
                var msAccessToken = executor.GetMicrosoftOnlineAccessToken(
                    executor.GetConfig("Azure.TenantId"),
                    "https://vault.azure.net",
                    executor.GetConfig("KeyVault.ClientId"),
                    executor.GetConfig("KeyVault.ClientSecret")
                );
                executor.CacheService.SetAbsolute(accessTokenCacheKey, msAccessToken.AccessToken, Convert.ToInt32(msAccessToken.ExpiresIn) - 30);
                accessToken = msAccessToken.AccessToken;
            }

            var request = GetRequest(HttpMethod.Get, new Uri($"{url}?api-version=7.0"), (string)accessToken);

            var response = HttpClient.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            using (request)
            using (response)
            {
                var json = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidPluginExecutionException($"Status {response.StatusCode}: {json}");
                }

                var secret = executor.SerializerService.JsonDeserialize<Secret>(json);
                if (!secret.Attributes.Enabled)
                {
                    throw new InvalidPluginExecutionException("Secret not enabled!");
                }

                executor.CacheService.SetAbsolute(url, secret.Value, 900);
                return secret.Value;
            }
        }

        private static HttpRequestMessage GetRequest(HttpMethod method, Uri uri, string accessToken)
        {
            var request = new HttpRequestMessage(method, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue(HttpUtils.Bearer, accessToken);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpUtils.ApplicationJson));
            request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue(HttpUtils.Utf8));
            request.Properties["RequestTimeout"] = TimeSpan.FromMilliseconds(Timeout);
            return request;
        }
    }
}
