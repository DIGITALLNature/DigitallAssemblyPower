// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.ServiceModel;
using Digitall.APower;
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

            // Construct the local plug-in context.
            var pluginCore = new PluginCore(serviceProvider);

            pluginCore.TracingService.Trace($"Entered {nameof(VanillaSample)}.Execute() " +
                                     $"Correlation Id: {pluginCore.PluginExecutionContext.CorrelationId}, " +
                                     $"Initiating User: {pluginCore.PluginExecutionContext.InitiatingUserId}");

            try
            {
                // Invoke the custom implementation

                return;
            }
            catch (FaultException<OrganizationServiceFault> orgServiceFault)
            {
                pluginCore.Trace($"Exception: {orgServiceFault.ToString()}");

                throw new InvalidPluginExecutionException($"OrganizationServiceFault: {orgServiceFault.Message}", orgServiceFault);
            }
            finally
            {
                pluginCore.Trace($"Exiting {nameof(VanillaSample)}.Execute()");
            }
        }
    }
}
