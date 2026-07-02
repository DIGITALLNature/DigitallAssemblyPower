// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.ServiceModel;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;

namespace SamplePlugin
{
    public class VanillaSample : IPlugin
    {

        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new InvalidPluginExecutionException(nameof(serviceProvider));
            }

            var executionContext = serviceProvider.GetExecutionContext();
            var tracing = serviceProvider.GetTracingService();

            tracing.Trace($"Entered {nameof(VanillaSample)}.Execute() " +
                          $"Correlation Id: {executionContext.CorrelationId}, " +
                          $"Initiating User: {executionContext.InitiatingUserId}");


            // Add your custom implementation of the plug-in.
            try
            {
                // Invoke the custom implementation
            }
            catch (FaultException<OrganizationServiceFault> orgServiceFault)
            {
                tracing.Trace($"Exception: {orgServiceFault}");

                throw new InvalidPluginExecutionException($"OrganizationServiceFault: {orgServiceFault.Message}", orgServiceFault);
            }
            finally
            {
                tracing.Trace($"Exiting {nameof(VanillaSample)}.Execute()");
            }
        }
    }
}
