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
    public class EntityAttributeExtensionTests
    {
        [TestMethod]
        public void GetEntityAttributeValueTests()
        {
            var testContext = new PluginExecutionTestContext();

            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            var pluginCore = new PluginCore(serviceProvider);
            Assert.IsNull(pluginCore.GetEntityAttributeValue<string>("fieldname"));
            testContext.PreImage.Attributes["fieldname"] = "imagevalue";
            Assert.AreEqual("imagevalue", pluginCore.GetEntityAttributeValue<string>("fieldname"));
            testContext.Target.Attributes["fieldname"] = "targetvalue";
            Assert.AreEqual("targetvalue", pluginCore.GetEntityAttributeValue<string>("fieldname"));

            Assert.ThrowsException<InvalidCastException>(() => pluginCore.GetEntityAttributeValue<int>("fieldname"));

            testContext.Target.Attributes["fieldname"] = 123;
            Assert.AreEqual(123, pluginCore.GetEntityAttributeValue<int>("fieldname"));

        }
    }
}
