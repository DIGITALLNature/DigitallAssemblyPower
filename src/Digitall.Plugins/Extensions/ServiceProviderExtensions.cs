using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Digitall.Plugins.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using IPluginLogger = Microsoft.Xrm.Sdk.PluginTelemetry.ILogger;
// ReSharper disable UnusedMember.Global

namespace Digitall.Plugins.Extensions;

public static class ServiceProviderExtensions
{
    /// <param name="serviceProvider">The service provider.</param>
    extension(IServiceProvider serviceProvider)
    {
        /// <summary>
        ///     Returns the <see cref="IPluginExecutionContext7" /> from the service provider.
        /// </summary>
        /// <returns>The <see cref="IPluginExecutionContext7" />.</returns>
        public IPluginExecutionContext7 GetExecutionContext() => serviceProvider.Get<IPluginExecutionContext7>();

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the current execution context's user.
        /// </summary>
        /// <returns>The <see cref="IOrganizationService"/> for the user specified in the execution context.</returns>
        public IOrganizationService GetOrganizationService()
        {
            var executionContext = serviceProvider.GetExecutionContext();
            return serviceProvider.GetOrganizationService(executionContext.UserId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user id of the user for which to retrieve the organization service.</param>
        /// <returns>The <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.</returns>
        public IOrganizationService GetOrganizationService(Guid userId)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(userId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> with the "System" user id (i.e. elevated privileges).
        /// </summary>
        /// <returns>The <see cref="IOrganizationService"/> with elevated privileges.</returns>
        public IOrganizationService GetElevatedOrganizationService()
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(null);
        }

        /// <summary>
        ///     Retrieves the <see cref="ITracingService"/> from the service provider.
        /// </summary>
        /// <returns>The <see cref="ITracingService"/>.</returns>
        public ITracingService GetTracingService() => serviceProvider.Get<ITracingService>();

        /// <summary>
        /// Retrieves the <see cref="Microsoft.Xrm.Sdk.PluginTelemetry.ILogger"/> from the service provider.
        /// </summary>
        /// <returns>The <see cref="Microsoft.Xrm.Sdk.PluginTelemetry.ILogger"/>.</returns>
        public IPluginLogger GetLogger() => serviceProvider.Get<IPluginLogger>();

        /// <summary>
        /// Retrieves an instance of the <see cref="ISerializerService"/> from the service provider.
        /// </summary>
        /// <returns>An instance of the <see cref="ISerializerService"/>.</returns>
        public static ISerializerService GetSerializerService() => new SerializerService();

        /// <summary>
        /// Retrieves the <see cref="TimeProvider"/> from the service provider.
        /// It should be used when implementing date-dependent logic and enables unit testing.
        /// In Dataverse runtime, this falls back to <see cref="TimeProvider.System"/> when no provider is registered.
        /// </summary>
        /// <returns>The <see cref="TimeProvider"/> instance.</returns>
        public TimeProvider GetTimeProvider() => serviceProvider.Get<TimeProvider>() ?? TimeProvider.System;

        /// <summary>
        /// Retrieves the <see cref="ILoggingFacade" /> from the service provider.
        /// </summary>
        /// <returns>An instance of <see cref="ILoggingFacade" />.</returns>
        [Obsolete(
            "Use GetLogger(LogSink.PluginTelemetry, LogSink.TracingService) instead to get a " +
            "Microsoft.Extensions.Logging.ILogger compatible logger which logs to both ILogger and ITracingService.")]
        public ILoggingFacade GetLoggingFacade()
        {
            var tracingService = serviceProvider.GetTracingService();
            var logger = serviceProvider.GetLogger();
            return new LoggingFacade(tracingService, logger);
        }

        /// <summary>
        /// Retrieves an <see cref="ILogger{TCategoryName}"/> for the specified plugin type.
        /// </summary>
        /// <typeparam name="TPlugin">The plugin type used as the logger category.</typeparam>
        /// <returns>An <see cref="ILogger{TCategoryName}"/> backed by the plugin telemetry logger.</returns>
        public ILogger<TPlugin> GetLogger<TPlugin>() where TPlugin : IPlugin
        {
            var logger = serviceProvider.GetLogger();
            return new PluginLoggingAdapter<TPlugin>(logger);
        }

        /// <summary>
        /// Retrieves the <see cref="IManagedIdentityService"/> from the service provider.
        /// </summary>
        /// <returns>An instance of <see cref="IManagedIdentityService" />.</returns>
        public IManagedIdentityService GetManagedIdentityService() => serviceProvider.Get<IManagedIdentityService>();

        /// <summary>
        /// Registers the proxy types assembly for the <see cref="IOrganizationServiceFactory"/>.
        /// </summary>
        /// <remarks>
        /// This is a workaround for a known issue in Dynamics 365 where the <see cref="IOrganizationServiceFactory"/> doesn't
        /// automatically load the proxy types assembly when the service provider is created.
        ///
        /// The Behavior is undocumented and usage is without any warrenty!
        /// </remarks>
        /// <param name="assembly">The assembly containing the proxy types.</param>
        /// <returns>The service provider.</returns>
        [SuppressMessage("Major Code Smell", "S3011", Justification = "Dataverse plugin runtime requires setting ProxyTypesAssembly via reflection.")]
        public IServiceProvider RegisterProxyTypesAssembly(Assembly assembly)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            var property = factory.GetType().GetProperty("ProxyTypesAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            property?.SetValue(factory, assembly, null);

            return serviceProvider;
        }
    }
}