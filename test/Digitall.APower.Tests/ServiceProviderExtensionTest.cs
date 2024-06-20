// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Digitall.APower.Tester;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using NSubstitute;

namespace Digitall.APower.Tests
{
    [TestClass]
    public class ServiceProviderExtensionTest
    {
        [TestMethod]
        public void GetExecutionContextTest()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext<Entity>();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Get the execution context
            var executionContext = serviceProvider.GetExecutionContext();
            Assert.IsNotNull(executionContext);
            Assert.AreSame(testContext.Context, executionContext);
        }
    }
}
