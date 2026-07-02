// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk.Metadata;

namespace Digitall.Plugins.Tests.Extensions;

public class EnvironmentVariablesExtensionTests
{
    // FakeOrganizationService requires entity metadata registration for RetrieveMultiple queries.
    // environmentvariabledefinition and environmentvariablevalue must be in the MetadataCache.
    private static FakeDataverseBuilder AddEnvVarMetadata(FakeDataverseBuilder builder) =>
        builder
            .AddEntityMetadata(new EntityMetadata { LogicalName = "environmentvariabledefinition" })
            .AddEntityMetadata(new EntityMetadata { LogicalName = "environmentvariablevalue" });

    private static IServiceProvider BuildServiceProvider(FakeOrganizationService service)
    {
        return new PluginExecutionContextBuilder(service).BuildServiceProvider();
    }

    // ── GetConfig via IServiceProvider ────────────────────────────────────────

    [Test]
    public async Task GetConfig_WhenVariableNotRegistered_ReturnsParameterDefault()
    {
        var service = (FakeOrganizationService)AddEnvVarMetadata(new FakeDataverseBuilder())
            .GetOrganizationService();

        var result = BuildServiceProvider(service).GetConfig("unknown.setting", "param-default");

        await Assert.That(result).IsEqualTo("param-default");
    }

    [Test]
    public async Task GetConfig_WhenVariableNotRegisteredAndNoDefault_ReturnsNull()
    {
        var service = (FakeOrganizationService)AddEnvVarMetadata(new FakeDataverseBuilder())
            .GetOrganizationService();

        var result = BuildServiceProvider(service).GetConfig("unknown.setting");

        await Assert.That(result).IsNull();
    }

    // ── Null guards ───────────────────────────────────────────────────────────

    [Test]
    public async Task GetConfig_NullServiceProvider_ThrowsArgumentNullException()
    {
        var ex = await Assert.That(() => ((IServiceProvider)null).GetConfig("key")).ThrowsException();
        await Assert.That(ex).IsTypeOf<ArgumentNullException>();
    }
}
