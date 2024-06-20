using System;
using Digitall.APower.Contracts;
using Digitall.APower.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using Microsoft.Xrm.Sdk.PluginTelemetry;

namespace Digitall.APower
{
    public static class ServiceProviderExtensions
    {
        public static IPluginExecutionContext GetExecutionContext(this IServiceProvider serviceProvider) =>
            serviceProvider.Get<IPluginExecutionContext5>();

        public static IOrganizationService GetOrganizationService(this IServiceProvider serviceProvider)
        {
            var executionContext = serviceProvider.GetExecutionContext();
            return serviceProvider.GetOrganizationService(executionContext.UserId);
        }

        public static IOrganizationService GetOrganizationService(this IServiceProvider serviceProvider, Guid userId)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(userId);
        }

        public static IOrganizationService GetElevatedOrganizationService(this IServiceProvider serviceProvider)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(null);
        }

        public static ITracingService GetTracingService(this IServiceProvider serviceProvider) =>
            serviceProvider.Get<ITracingService>();

        public static ILogger GetLogger(this IServiceProvider serviceProvider) => serviceProvider.Get<ILogger>();

        public static ISerializerService GetSerializerService(this IServiceProvider serviceProvider) => new SerializerService();

        public static ILoggingFacade GetLoggingFacade(this IServiceProvider serviceProvider)
        {
            var tracingService = serviceProvider.GetTracingService();
            var logger = serviceProvider.GetLogger();
            return new LoggingFacade(tracingService, logger);
        }
    }
}
