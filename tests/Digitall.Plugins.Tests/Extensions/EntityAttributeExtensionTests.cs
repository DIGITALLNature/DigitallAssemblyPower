// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Digitall.Plugins.Tests.Extensions;

public class EntityAttributeExtensionTests
{
    private static IPluginExecutionContext7 BuildContext(Entity target, Entity preImage = null)
    {
        var service = new FakeOrganizationService();
        var builder = new PluginExecutionContextBuilder(service).WithTarget(target);
        if (preImage != null)
        {
            builder = builder.WithPreEntityImage(preImage);
        }

        return (IPluginExecutionContext7)builder.BuildServiceProvider().GetService(typeof(IPluginExecutionContext7));
    }

    // ── GetEntityAttributeValue ───────────────────────────────────────────────

    [Test]
    public async Task GetEntityAttributeValue_FromTarget_ReturnsValue()
    {
        var target = new Entity("account") { Id = Guid.NewGuid(), ["name"] = "ACME" };
        var ctx = BuildContext(target);

        var result = ctx.GetEntityAttributeValue<string>("name");

        await Assert.That(result).IsEqualTo("ACME");
    }

    [Test]
    public async Task GetEntityAttributeValue_FallsBackToPreImage_WhenNotInTarget()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id };              // no "name"
        var preImage = new Entity("account") { Id = id, ["name"] = "Legacy" };
        var ctx = BuildContext(target, preImage);

        var result = ctx.GetEntityAttributeValue<string>("name");

        await Assert.That(result).IsEqualTo("Legacy");
    }

    [Test]
    public async Task GetEntityAttributeValue_WhenInNeither_ReturnsDefault()
    {
        var ctx = BuildContext(new Entity("account") { Id = Guid.NewGuid() });

        var result = ctx.GetEntityAttributeValue<string>("revenue");

        await Assert.That(result).IsNull();
    }

    // ── IsEntityAttributeValueNew ─────────────────────────────────────────────

    [Test]
    public async Task IsEntityAttributeValueNew_WhenOnlyInTarget_ReturnsTrue()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "New" };
        var preImage = new Entity("account") { Id = id }; // no "name"
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueNew("name")).IsTrue();
    }

    [Test]
    public async Task IsEntityAttributeValueNew_WhenAlsoInPreImage_ReturnsFalse()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "Updated" };
        var preImage = new Entity("account") { Id = id, ["name"] = "Old" };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueNew("name")).IsFalse();
    }

    [Test]
    public async Task IsEntityAttributeValueNew_WhenNotInTarget_ReturnsFalse()
    {
        var ctx = BuildContext(new Entity("account") { Id = Guid.NewGuid() });

        await Assert.That(ctx.IsEntityAttributeValueNew("name")).IsFalse();
    }

    // ── IsEntityAttributeValueChanged ─────────────────────────────────────────

    [Test]
    public async Task IsEntityAttributeValueChanged_WhenValueDiffers_ReturnsTrue()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "New Name" };
        var preImage = new Entity("account") { Id = id, ["name"] = "Old Name" };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueChanged<string>("name")).IsTrue();
    }

    [Test]
    public async Task IsEntityAttributeValueChanged_WhenValueSame_ReturnsFalse()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "Same" };
        var preImage = new Entity("account") { Id = id, ["name"] = "Same" };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueChanged<string>("name")).IsFalse();
    }

    [Test]
    public async Task IsEntityAttributeValueChanged_WhenNoPreImage_ReturnsTrue()
    {
        var target = new Entity("account") { Id = Guid.NewGuid(), ["name"] = "Any" };
        var ctx = BuildContext(target); // no preimage

        await Assert.That(ctx.IsEntityAttributeValueChanged<string>("name")).IsTrue();
    }

    [Test]
    public async Task IsEntityAttributeValueChanged_WhenNotInTarget_ReturnsFalse()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id }; // no "name"
        var preImage = new Entity("account") { Id = id, ["name"] = "Old" };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueChanged<string>("name")).IsFalse();
    }

    // ── IsEntityAttributeValueNullOrEmpty ─────────────────────────────────────

    [Test]
    public async Task IsEntityAttributeValueNullOrEmpty_WhenBothNull_ReturnsTrue()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = null };
        var preImage = new Entity("account") { Id = id, ["name"] = null };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueNullOrEmpty("name")).IsTrue();
    }

    [Test]
    public async Task IsEntityAttributeValueNullOrEmpty_WhenTargetHasValue_ReturnsFalse()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "Filled" };
        var preImage = new Entity("account") { Id = id };
        var ctx = BuildContext(target, preImage);

        await Assert.That(ctx.IsEntityAttributeValueNullOrEmpty("name")).IsFalse();
    }
}
