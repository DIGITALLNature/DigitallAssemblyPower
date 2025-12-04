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
        extension(IServiceProvider serviceProvider)
        {
            /// <summary>
            /// Retrieves the <see cref="IPluginExecutionContext"/> from the service provider.
            /// </summary>
            /// <returns>The <see cref="IPluginExecutionContext"/></returns>
            public IPluginExecutionContext7 GetExecutionContext() => serviceProvider.Get<IPluginExecutionContext7>();

            /// <summary>
            /// Retrieves the <see cref="IOrganizationService"/> for the user associated with the current execution context from the service provider.
            /// </summary>
            /// <returns>The <see cref="IOrganizationService"/> for the user associated with the current execution context.</returns>
            public IOrganizationService GetOrganizationService()
            {
                var executionContext = serviceProvider.GetExecutionContext();
                return serviceProvider.GetOrganizationService(executionContext.UserId);
            }

            /// <summary>
            /// Retrieves the <see cref="IOrganizationService"/> for the specified user id from the service provider.
            /// </summary>
            /// <param name="userId">id of the user</param>
            /// <returns>The <see cref="IOrganizationService"/> for the user</returns>
            public IOrganizationService GetOrganizationService(Guid userId)
            {
                var factory = serviceProvider.Get<IOrganizationServiceFactory>();
                return factory.CreateOrganizationService(userId);
            }

            /// <summary>
            /// Retrieves an elevated <see cref="IOrganizationService"/> instance with system-level privileges from the service provider.
            /// </summary>
            /// <returns>An <see cref="IOrganizationService"/> instance with system-level privileges.</returns>
            public IOrganizationService GetElevatedOrganizationService()
            {
                var factory = serviceProvider.Get<IOrganizationServiceFactory>();
                return factory.CreateOrganizationService(null);
            }

            /// <summary>
            /// Retrieves the <see cref="ITracingService"/> from the service provider.
            /// </summary>
            /// <returns>The <see cref="ITracingService"/> for the current execution context.</returns>
            public ITracingService GetTracingService() => serviceProvider.Get<ITracingService>();

            /// <summary>
            /// Retrieves the <see cref="ILogger"/> instance from the service provider.
            /// </summary>
            /// <returns>The <see cref="ILogger"/> instance.</returns>
            public ILogger GetLogger() => serviceProvider.Get<ILogger>();

            /// <summary>
            /// Retrieves an instance of <see cref="ISerializerService"/> for handling JSON serialization and deserialization.
            /// </summary>
            /// <returns>An implementation of <see cref="ISerializerService"/>.</returns>
            public ISerializerService GetSerializerService() => new SerializerService();

            /// <summary>
            /// Creates an instance of <see cref="ILoggingFacade"/> utilizing the tracing service and logger retrieved from the service provider.
            /// </summary>
            /// <returns>An <see cref="ILoggingFacade"/> instance configured with the appropriate tracing and logging services.</returns>
            public ILoggingFacade GetLoggingFacade()
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
            /// The Behavior is undocumented and usage is without any warranty!
            /// </remarks>
            /// <param name="assembly">The assembly containing the proxy types.</param>
            /// <returns>The service provider.</returns>
            public IServiceProvider RegisterProxyTypesAssembly(Assembly assembly)
            {
                var factory = serviceProvider.Get<IOrganizationServiceFactory>();
                var property = factory.GetType().GetProperty("ProxyTypesAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
                property?.SetValue(factory, assembly, null);

                return serviceProvider;
            }
        }
    }
}
