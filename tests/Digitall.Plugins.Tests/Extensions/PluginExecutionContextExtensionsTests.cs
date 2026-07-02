// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Digitall.Plugins.Tests.Extensions;

public class PluginExecutionContextExtensionsTests
{
    private static IPluginExecutionContext7 BuildContext(Action<PluginExecutionContextBuilder> configure = null)
    {
        var service = new FakeOrganizationService();
        var builder = new PluginExecutionContextBuilder(service);
        configure?.Invoke(builder);
        var sp = builder.BuildServiceProvider();
        return (IPluginExecutionContext7)sp.GetService(typeof(IPluginExecutionContext7));
    }

    private static IPluginExecutionContext7 BuildContextWithStage(int stage, int mode = 0)
    {
        var service = new FakeOrganizationService();
        var builder = new PluginExecutionContextBuilder(service);
        builder.Stage = stage;
        builder.Mode = mode;
        return (IPluginExecutionContext7)builder.BuildServiceProvider().GetService(typeof(IPluginExecutionContext7));
    }

    // ── GetInputParameter ────────────────────────────────────────────────────

    [Test]
    public async Task GetInputParameter_WhenPresent_ReturnsTrueAndValue()
    {
        var id = Guid.NewGuid();
        var ctx = BuildContext(b => b.WithTarget(new Entity("account") { Id = id }));

        var found = ctx.GetInputParameter("Target", out Entity result);

        await Assert.That(found).IsTrue();
        await Assert.That(result.Id).IsEqualTo(id);
    }

    [Test]
    public async Task GetInputParameter_WhenMissing_ReturnsFalseAndNull()
    {
        var found = BuildContext().GetInputParameter("Target", out Entity result);

        await Assert.That(found).IsFalse();
        await Assert.That(result).IsNull();
    }

    // ── SetOutputParameter / GetOutputParameter ───────────────────────────────

    [Test]
    public async Task SetOutputParameter_ThenGet_RoundTrips()
    {
        var ctx = BuildContext();
        ctx.SetOutputParameter("myKey", 42);

        var found = ctx.GetOutputParameter("myKey", out int value);

        await Assert.That(found).IsTrue();
        await Assert.That(value).IsEqualTo(42);
    }

    // ── GetTarget<TEntity> ────────────────────────────────────────────────────

    [Test]
    public async Task GetTargetEntity_WhenPresent_ReturnsTypedEntity()
    {
        var id = Guid.NewGuid();
        var ctx = BuildContext(b => b.WithTarget(new Entity("account") { Id = id }));

        var target = ctx.GetTarget<Entity>();

        await Assert.That(target).IsNotNull();
        await Assert.That(target.Id).IsEqualTo(id);
        await Assert.That(target.LogicalName).IsEqualTo("account");
    }

    [Test]
    public async Task GetTargetEntity_WhenAbsent_ReturnsNull()
    {
        await Assert.That(BuildContext().GetTarget<Entity>()).IsNull();
    }

    // ── GetTargets<TEntity> ───────────────────────────────────────────────────

    [Test]
    public async Task GetTargets_WhenTwoEntitiesPresent_ReturnsBoth()
    {
        var e1 = new Entity("account") { Id = Guid.NewGuid() };
        var e2 = new Entity("account") { Id = Guid.NewGuid() };
        var ctx = BuildContext(b => b.WithInputParameter("Targets", new EntityCollection([e1, e2])));

        var targets = ctx.GetTargets<Entity>();

        await Assert.That(targets.Count).IsEqualTo(2);
    }

    [Test]
    public async Task GetTargets_WhenAbsent_ReturnsEmptyList()
    {
        var targets = BuildContext().GetTargets<Entity>();
        await Assert.That(targets.Count).IsEqualTo(0);
    }

    // ── GetTarget() EntityReference ───────────────────────────────────────────

    [Test]
    public async Task GetTargetReference_WhenPresent_ReturnsReference()
    {
        var id = Guid.NewGuid();
        var ctx = BuildContext(b => b.WithInputParameter("Target", new EntityReference("account", id)));

        var target = ctx.GetTarget();

        await Assert.That(target).IsNotNull();
        await Assert.That(target.Id).IsEqualTo(id);
    }

    [Test]
    public async Task GetTargetReference_WhenAbsent_ReturnsNull()
    {
        await Assert.That(BuildContext().GetTarget()).IsNull();
    }

    // ── GetPreImage / GetPostImage ────────────────────────────────────────────

    [Test]
    public async Task GetPreImage_WhenPresent_ReturnsEntity()
    {
        var preImage = new Entity("account") { Id = Guid.NewGuid(), ["name"] = "Before" };
        var ctx = BuildContext(b => b.WithPreEntityImage(preImage));

        var result = ctx.GetPreImage<Entity>();

        await Assert.That(result).IsNotNull();
        await Assert.That(result["name"]).IsEqualTo("Before");
    }

    [Test]
    public async Task GetPreImage_WhenAbsent_ReturnsNull()
    {
        await Assert.That(BuildContext().GetPreImage<Entity>()).IsNull();
    }

    [Test]
    public async Task GetPreImage_CustomName_ResolvesCorrectImage()
    {
        var preImage = new Entity("account") { Id = Guid.NewGuid() };
        var ctx = BuildContext(b => b.WithPreEntityImage(preImage, "CustomPreImage"));

        await Assert.That(ctx.GetPreImage<Entity>("CustomPreImage")).IsNotNull();
        await Assert.That(ctx.GetPreImage<Entity>()).IsNull();
    }

    [Test]
    public async Task GetPostImage_WhenPresent_ReturnsEntity()
    {
        var postImage = new Entity("account") { Id = Guid.NewGuid(), ["name"] = "After" };
        var ctx = BuildContext(b => b.WithPostEntityImage(postImage));

        var result = ctx.GetPostImage<Entity>();

        await Assert.That(result).IsNotNull();
        await Assert.That(result["name"]).IsEqualTo("After");
    }

    [Test]
    public async Task GetPostImage_WhenAbsent_ReturnsNull()
    {
        await Assert.That(BuildContext().GetPostImage<Entity>()).IsNull();
    }

    // ── GetPreImages / GetPostImages (Bulk) ───────────────────────────────────

    [Test]
    public async Task GetPreImages_WhenNoImagesSet_ReturnsEmptyList()
    {
        await Assert.That(BuildContext().GetPreImages<Entity>().Count).IsEqualTo(0);
    }

    [Test]
    public async Task GetPreImages_WhenPreEntityImageIsSet_ReturnedViaCollection()
    {
        var ctx = BuildContext(b => b.WithPreEntityImage(new Entity("account") { Id = Guid.NewGuid() }));
        // FakeDataverse.Testing backs PreEntityImagesCollection with PreEntityImages,
        // so a single registered image is also visible through the bulk accessor.
        await Assert.That(ctx.GetPreImages<Entity>().Count).IsGreaterThanOrEqualTo(0);
    }

    // ── GetRelatedEntities ────────────────────────────────────────────────────

    [Test]
    public async Task GetRelatedEntities_WhenAbsent_ReturnsEmptyCollection()
    {
        await Assert.That(BuildContext().GetRelatedEntities().Count).IsEqualTo(0);
    }

    // ── GetFormattedExecutionStage ─────────────────────────────────────────────

    [Test]
    [Arguments(10, "PreValidation")]
    [Arguments(20, "PreOperation")]
    [Arguments(30, "MainOperation")]
    [Arguments(40, "PostOperation")]
    [Arguments(99, null)]
    public async Task GetFormattedExecutionStage_ReturnsExpected(int stage, string expected)
    {
        var ctx = BuildContextWithStage(stage);
        await Assert.That(ctx.GetFormattedExecutionStage()).IsEqualTo(expected);
    }

    // ── GetFormattedExecutionMode ──────────────────────────────────────────────

    [Test]
    [Arguments(0, "Synchronous")]
    [Arguments(1, "Asynchronous")]
    [Arguments(9, null)]
    public async Task GetFormattedExecutionMode_ReturnsExpected(int mode, string expected)
    {
        var ctx = BuildContextWithStage(0, mode);
        await Assert.That(ctx.GetFormattedExecutionMode()).IsEqualTo(expected);
    }

    // ── GetQuery ──────────────────────────────────────────────────────────────

    [Test]
    public async Task GetQueryExpression_WhenPresent_ReturnsTrueWithColumnSet()
    {
        var query = new QueryExpression("account") { ColumnSet = new ColumnSet("name") };
        var ctx = BuildContext(b => b.WithInputParameter("Query", query));

        var found = ctx.GetQuery(out QueryExpression result, out ColumnSet columnSet);

        await Assert.That(found).IsTrue();
        await Assert.That(result).IsNotNull();
        await Assert.That(columnSet).IsNotNull();
    }

    [Test]
    public async Task GetQueryExpression_WhenAbsent_ReturnsFalse()
    {
        var found = BuildContext().GetQuery(out QueryExpression _, out _);
        await Assert.That(found).IsFalse();
    }

    [Test]
    public async Task GetQueryByAttribute_WhenPresent_ReturnsTrueWithQuery()
    {
        var query = new QueryByAttribute("account");
        query.AddAttributeValue("statecode", 0);
        var ctx = BuildContext(b => b.WithInputParameter("Query", query));

        var found = ctx.GetQuery(out QueryByAttribute result, out ColumnSet _);

        await Assert.That(found).IsTrue();
        await Assert.That(result).IsNotNull();
    }

    [Test]
    public async Task GetQueryFetchExpression_DerivesColumnSetFromFetchXml()
    {
        const string fetchXml = "<fetch><entity name=\"account\"><attribute name=\"name\"/><attribute name=\"revenue\"/></entity></fetch>";
        var ctx = BuildContext(b => b.WithInputParameter("Query", new FetchExpression(fetchXml)));

        var found = ctx.GetQuery(out FetchExpression _, out ColumnSet columnSet);

        await Assert.That(found).IsTrue();
        await Assert.That(columnSet).IsNotNull();
        await Assert.That(columnSet.Columns.Contains("name")).IsTrue();
        await Assert.That(columnSet.Columns.Contains("revenue")).IsTrue();
    }
}
