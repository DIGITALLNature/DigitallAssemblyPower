// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Diagnostics;
using Microsoft.Xrm.Sdk;

namespace Digitall.APower
{
    public abstract class PluginSkeleton : IPlugin
    {
        /// <summary>
        /// Executes the plugin using the provided service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            // Get the logger from the service provider
            var logger = serviceProvider.GetLoggingFacade();

            // Start a stopwatch to measure execution time
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Get the execution context from the service provider
                var executionContext = serviceProvider.GetExecutionContext();

                // Log the start of the execution
                logger.LogInformation("Execution started {0}: Message {1} - Stage {2} - Mode {3}", GetType().FullName,
                    executionContext.MessageName, executionContext.GetFormattedExecutionStage(),
                    executionContext.GetFormattedExecutionMode());

                // Execute the plugin's internal logic
                ExecuteInternal(serviceProvider);
            }
            catch (Exception exception)
            {
                // Log any exceptions that occur during execution
                logger.LogError(exception, "Execution failed");
                throw;
            }
            finally
            {
                // Log the end of the execution and the elapsed time
                logger.LogInformation("Execution finished in {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }

        protected abstract void ExecuteInternal(IServiceProvider serviceProvider);
    }
}
