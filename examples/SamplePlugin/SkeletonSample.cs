// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using dgt.Model.Dataverse;
using Digitall.APower;
using Microsoft.Xrm.Sdk;

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
            // Get the execution context from the service provider
            var executionContext = serviceProvider.GetExecutionContext();

            // Get the formatted execution mode and stage from the execution context
            var executionMode = executionContext.GetFormattedExecutionMode();
            var executionStage = executionContext.GetFormattedExecutionStage();

            // Get the input parameter "TODO" from the execution context and store it in tmp variable
            executionContext.GetInputParameter("TODO", out EntityReference tmp);

            // Set the output parameter "Result" to 123 in the execution context
            executionContext.SetOutputParameter("Result", 123);

            // Get the target entity from the execution context and cast it to an Account
            var account = executionContext.GetTarget<Account>();

            // Get the target reference from the execution context
            var reference = executionContext.GetTarget();

            // Get the pre-image entity from the execution context and cast it to an Account
            var preImage = executionContext.GetPreImage<Account>();

            // Get the post-image entity from the execution context and cast it to an Account
            var postImage = executionContext.GetPostImage<Account>();

            // Get the secured organization service from the service provider
            var secured = serviceProvider.GetOrganizationService();

            // Get the elevated organization service from the service provider
            var elevated = serviceProvider.GetElevatedOrganizationService();

            // Get the tracing service from the service provider
            var tracing = serviceProvider.GetTracingService();

            // Get the logger from the service provider
            var logger = serviceProvider.GetLogger();

            // Get the logging facade from the service provider
            var facade = serviceProvider.GetLoggingFacade();

            // access to DateTime constants via provider
            var now = TimeProvider.GetLocalNow();
            var utcNow = TimeProvider.GetUtcNow();
        }
    }
}
