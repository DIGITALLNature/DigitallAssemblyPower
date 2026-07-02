// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using dgt.Model.Dataverse;
using Digitall.Plugins;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;
// ReSharper disable UnusedVariable
// ReSharper disable UnusedType.Global

namespace SamplePlugin
{
    public class SkeletonSample : PluginSkeleton
    {
        /// <summary>
        /// Executes the plugin using the provided service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected override void ExecuteInternal(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            // Get the execution context from the service provider
            var executionContext = serviceProvider.GetExecutionContext();

            // Get the formatted execution mode and stage from the execution context
            var executionMode = executionContext.GetFormattedExecutionMode();
            var executionStage = executionContext.GetFormattedExecutionStage();

            // Get the input parameter "SampleInput" from the execution context and store it in tmp variable
            executionContext.GetInputParameter("SampleInput", out EntityReference tmp);

            // Set the output parameter "Result" to a sample value in the execution context
            const int sampleResultValue = 123;
            executionContext.SetOutputParameter("Result", sampleResultValue);

            // Get the target entity from the execution context and cast it to an Account
            var account = executionContext.GetTarget<Account>();

            // Get the target reference from the execution context
            var reference = executionContext.GetTarget();

            // Get the target entities from the execution context and cast them to an Account collection
            // Note: This will only work if you register your plugin on CreateMultiple or UpdateMultiple messages
            var accounts = executionContext.GetTargets<Account>();

            // Get the pre-image entity from the execution context and cast it to an Account
            var preImage = executionContext.GetPreImage<Account>();

            // Get the pre-image entities from the execution context and cast them to an Account collection
            // Note: This will only work if you register your plugin on CreateMultiple or UpdateMultiple messages
            var preImages = executionContext.GetPreImages<Account>();

            // Get the post-image entity from the execution context and cast it to an Account
            var postImage = executionContext.GetPostImage<Account>();

            // Get the post-image entities from the execution context and cast them to an Account collection
            // Note: This will only work if you register your plugin on CreateMultiple or UpdateMultiple messages
            var postImages = executionContext.GetPostImages<Account>();

            // Get the secured organization service from the service provider
            var secured = serviceProvider.GetOrganizationService();

            // Get the elevated organization service from the service provider
            var elevated = serviceProvider.GetElevatedOrganizationService();

            // Get the tracing service from the service provider
            var tracing = serviceProvider.GetTracingService();

            // Get the Dataverse logger from the service provider
            var logger1 = serviceProvider.GetLogger();

            // Get a Microsoft.Extensions.Logging.ILogger compatible logger from the service provider
            // You can specify the log sinks you want to use: Microsoft.Xrm.Sdk.PluginTelemetry.ILogger / Microsoft.Xrm.Sdk.ITracingService / both
            // The logger logs to every sink specified
            // If no sinks are specified, TracingService is used as a fallback
            var logger2 = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.PluginTelemetry, ServiceProviderExtensions.LogSink.TracingService);

            // Get the managed identity service from the service provider
            var miService = serviceProvider.GetManagedIdentityService();
            var accessToken = miService.AcquireToken(["https://my.api.com/.default"]);

            // access to current DateTimeOffset values via provider
            var timeProvider = serviceProvider.GetTimeProvider();
            var now = timeProvider.GetLocalNow();
            var utcNow = timeProvider.GetUtcNow();
        }
    }
}
