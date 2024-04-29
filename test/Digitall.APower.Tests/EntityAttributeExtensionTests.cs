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
        const string Fieldname = "unittest_fieldname";
        const string PreImageValue = "unittest-imagevalue";
        const string TargetValue = "targetvalue";

        // Method to test the GetEntityAttributeValue method with various scenarios including null values and different types.
        [TestMethod]
        public void GetEntityAttributeValueTests()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Create a new instance of PluginCore and set the service provider
            var pluginCore = new PluginCore(serviceProvider);

            // Create a mock instance of Executor and set the plugin core
            var pluginExecutor = Substitute.For<Executor>("unsecure", "secure");
            pluginExecutor.Core.Returns(pluginCore);

            // Test GetEntityAttributeValue with null values
            Assert.IsNull(pluginCore.GetEntityAttributeValue<string>(Fieldname));
            Assert.IsNull(pluginExecutor.GetEntityAttributeValue<string>(Fieldname));

            // Set the pre-image attribute value and test GetEntityAttributeValue
            testContext.PreImage.Attributes[Fieldname] = PreImageValue;
            Assert.AreEqual(PreImageValue, pluginCore.GetEntityAttributeValue<string>(Fieldname));
            Assert.AreEqual(PreImageValue, pluginExecutor.GetEntityAttributeValue<string>(Fieldname));

            // Set the target attribute value and test GetEntityAttributeValue
            testContext.Target.Attributes[Fieldname] = TargetValue;
            Assert.AreEqual(TargetValue, pluginCore.GetEntityAttributeValue<string>(Fieldname));
            Assert.AreEqual(TargetValue, pluginExecutor.GetEntityAttributeValue<string>(Fieldname));

            // Test GetEntityAttributeValue with invalid cast exception
            Assert.ThrowsException<InvalidCastException>(() => pluginCore.GetEntityAttributeValue<int>(Fieldname));
            Assert.ThrowsException<InvalidCastException>(() => pluginExecutor.GetEntityAttributeValue<int>(Fieldname));

            // Set the target attribute value as integer and test GetEntityAttributeValue
            testContext.Target.Attributes[Fieldname] = 123;
            Assert.AreEqual(123, pluginCore.GetEntityAttributeValue<int>(Fieldname));
            Assert.AreEqual(123, pluginExecutor.GetEntityAttributeValue<int>(Fieldname));
        }

        // Method to test the IsEntityAttributeValueNew method with various scenarios including null values and different types.
        [TestMethod]
        public void IsEntityAttributeValueNewTests()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Create a new instance of PluginCore and set the service provider
            var pluginCore = new PluginCore(serviceProvider);

            // Create a mock instance of Executor and set the plugin core
            var pluginExecutor = Substitute.For<Executor>("unsecure", "secure");
            pluginExecutor.Core.Returns(pluginCore);

            // Test IsEntityAttributeValueNew with null values
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNew(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNew(Fieldname));

            // Set the pre-image attribute value and test IsEntityAttributeValueNew
            testContext.PreImage.Attributes[Fieldname] = PreImageValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNew(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNew(Fieldname));

            // Set the target attribute value and test IsEntityAttributeValueNew
            testContext.Target.Attributes[Fieldname] = TargetValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNew(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNew(Fieldname));

            // Remove the pre-image attribute value and test IsEntityAttributeValueNew
            testContext.PreImage.Attributes.Remove(Fieldname);
            Assert.IsTrue(pluginCore.IsEntityAttributeValueNew(Fieldname));
            Assert.IsTrue(pluginExecutor.IsEntityAttributeValueNew(Fieldname));
        }

        // Method to test the IsEntityAttributeValueChanged method with various scenarios including null values and different types.
        [TestMethod]
        public void IsEntityAttributeValueChangedTests()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Create a new instance of PluginCore and set the service provider
            var pluginCore = new PluginCore(serviceProvider);

            // Create a mock instance of Executor and set the plugin core
            var pluginExecutor = Substitute.For<Executor>("unsecure", "secure");
            pluginExecutor.Core.Returns(pluginCore);

            // Test IsEntityAttributeValueNew with null values
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNew(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNew(Fieldname));

            // Set the pre-image attribute value and test IsEntityAttributeValueChanged
            testContext.PreImage.Attributes[Fieldname] = PreImageValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueChanged<string>(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueChanged<string>(Fieldname));

            // Set the target attribute value and test IsEntityAttributeValueChanged unchanged
            testContext.Target.Attributes[Fieldname] = PreImageValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueChanged<string>(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueChanged<string>(Fieldname));

            // Set the target attribute value and test IsEntityAttributeValueChanged changed
            testContext.Target.Attributes[Fieldname] = TargetValue;
            Assert.IsTrue(pluginCore.IsEntityAttributeValueChanged<string>(Fieldname));
            Assert.IsTrue(pluginExecutor.IsEntityAttributeValueChanged<string>(Fieldname));

            // Remove the pre-image attribute value and test IsEntityAttributeValueChanged
            testContext.PreImage.Attributes.Remove(Fieldname);
            Assert.IsTrue(pluginCore.IsEntityAttributeValueChanged<string>(Fieldname));
            Assert.IsTrue(pluginExecutor.IsEntityAttributeValueChanged<string>(Fieldname));
        }

        // Method to test the IsEntityAttributeValueNullOrEmpty method with various scenarios including null values and different types.
        [TestMethod]
        public void IsEntityAttributeValueNullOrEmptyTests()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Create a new instance of PluginCore and set the service provider
            var pluginCore = new PluginCore(serviceProvider);

            // Create a mock instance of Executor and set the plugin core
            var pluginExecutor = Substitute.For<Executor>("unsecure", "secure");
            pluginExecutor.Core.Returns(pluginCore);

            // Test IsEntityAttributeValueNullOrEmpty with null values
            Assert.IsTrue(pluginCore.IsEntityAttributeValueNullOrEmpty(Fieldname));
            Assert.IsTrue(pluginExecutor.IsEntityAttributeValueNullOrEmpty(Fieldname));

            // Set the pre-image attribute value and test IsEntityAttributeValueNullOrEmpty
            testContext.PreImage.Attributes[Fieldname] = PreImageValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNullOrEmpty(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNullOrEmpty(Fieldname));

            // Set the target attribute value and test IsEntityAttributeValueNullOrEmpty
            testContext.Target.Attributes[Fieldname] = TargetValue;
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNullOrEmpty(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNullOrEmpty(Fieldname));

            // Remove the pre-image attribute value and test IsEntityAttributeValueNullOrEmpty
            testContext.PreImage.Attributes.Remove(Fieldname);
            Assert.IsFalse(pluginCore.IsEntityAttributeValueNullOrEmpty(Fieldname));
            Assert.IsFalse(pluginExecutor.IsEntityAttributeValueNullOrEmpty(Fieldname));
        }

        // Method to test the MergeEntity method with various scenarios including null values and different types.
        [TestMethod]
        [Ignore("Test needs a early bound test-entity - TODO")]
        public void MergeEntityTests()
        {
            // Create a new instance of PluginExecutionTestContext
            var testContext = new PluginExecutionTestContext();

            // Create a mock service provider
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IPluginExecutionContext5)).Returns(testContext.Context);

            // Create a new instance of PluginCore and set the service provider
            var pluginCore = new PluginCore(serviceProvider);

            // Create a mock instance of Executor and set the plugin core
            var pluginExecutor = Substitute.For<Executor>("unsecure", "secure");
            pluginExecutor.Core.Returns(pluginCore);

            testContext.PreImage.Attributes["A"] = "A";
            testContext.Target.Attributes["B"] = "B";
            testContext.PreImage.Attributes["C"] = "C";
            testContext.Target.Attributes["C"] = "D";

            var mergedCore = pluginCore.MergeEntity<Entity>();
            Assert.AreEqual("A", mergedCore["A"]);
            Assert.AreEqual("B", mergedCore["B"]);
            Assert.AreEqual("C", mergedCore["D"]);
            var mergedExecutor = pluginExecutor.MergeEntity<Entity>();
            Assert.AreEqual("A", mergedExecutor["A"]);
            Assert.AreEqual("B", mergedExecutor["B"]);
            Assert.AreEqual("C", mergedExecutor["D"]);
        }
    }
}
