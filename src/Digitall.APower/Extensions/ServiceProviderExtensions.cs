using System;
using System.Reflection;
using Digitall.APower.Contracts;
using Digitall.APower.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using Microsoft.Xrm.Sdk.PluginTelemetry;

namespace Digitall.APower
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        ///     Returns the <see cref="IPluginExecutionContext7" /> from the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IPluginExecutionContext7" />.</returns>
        public static IPluginExecutionContext7 GetExecutionContext(this IServiceProvider serviceProvider) => serviceProvider.Get<IPluginExecutionContext7>();

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the current execution context's user.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IOrganizationService"/> for the user specified in the execution context.</returns>
        public static IOrganizationService GetOrganizationService(this IServiceProvider serviceProvider)
        {
            var executionContext = serviceProvider.GetExecutionContext();
            return serviceProvider.GetOrganizationService(executionContext.UserId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="userId">The user id of the user for which to retrieve the organization service.</param>
        /// <returns>The <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.</returns>
        public static IOrganizationService GetOrganizationService(this IServiceProvider serviceProvider, Guid userId)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(userId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> with the "System" user id (i.e. elevated privileges).
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IOrganizationService"/> with elevated privileges.</returns>
        public static IOrganizationService GetElevatedOrganizationService(this IServiceProvider serviceProvider)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(null);
        }

        /// <summary>
        ///     Retrieves the <see cref="ITracingService"/> from the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="ITracingService"/>.</returns>
        public static ITracingService GetTracingService(this IServiceProvider serviceProvider) => serviceProvider.Get<ITracingService>();

        /// <summary>
        /// Retrieves the <see cref="ILogger"/> from the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="ILogger"/>.</returns>
        public static ILogger GetLogger(this IServiceProvider serviceProvider) => serviceProvider.Get<ILogger>();

        /// <summary>
        /// Retrieves an instance of the <see cref="ISerializerService"/> from the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An instance of the <see cref="ISerializerService"/>.</returns>
        public static ISerializerService GetSerializerService(this IServiceProvider serviceProvider) => new SerializerService();

        /// <summary>
        /// Retrieves the <see cref="TimeProvider"/> from the service provider.
        /// It should be used when implementing date-dependent logic and enables unit testing.
        /// In Dataverse runtime, this falls back to <see cref="TimeProvider.System"/> when no provider is registered.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="TimeProvider"/> instance.</returns>
        public static TimeProvider GetTimeProvider(this IServiceProvider serviceProvider) => serviceProvider.Get<TimeProvider>() ?? TimeProvider.System;

        /// <summary>
        /// Retrieves the <see cref="ILoggingFacade" /> from the service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An instance of <see cref="ILoggingFacade" />.</returns>
        public static ILoggingFacade GetLoggingFacade(this IServiceProvider serviceProvider)
        {
            var tracingService = serviceProvider.GetTracingService();
            var logger = serviceProvider.GetLogger();
            return new LoggingFacade(tracingService, logger);
        }

        /// <summary>
        /// Registers the proxy types assembly for the <see cref="IOrganizationServiceFactory"/>.
        /// </summary>
        /// <remarks>
        /// This is a workaround for a known issue in Dynamics 365 where the <see cref="IOrganizationServiceFactory"/> doesn't
        /// automatically load the proxy types assembly when the service provider is created.
        ///
        /// The Behavior is undocumented and usage is without any warrenty!
        /// </remarks>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="assembly">The assembly containing the proxy types.</param>
        /// <returns>The service provider.</returns>
        public static IServiceProvider RegisterProxyTypesAssembly(this IServiceProvider serviceProvider, Assembly assembly)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            var property = factory.GetType().GetProperty("ProxyTypesAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(factory, assembly, null);

            return serviceProvider;
        }
    }
}
