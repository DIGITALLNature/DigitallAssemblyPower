// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Microsoft.Extensions.Time.Testing;
using Microsoft.Xrm.Sdk;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Digitall.Plugins.Tests;

public class PluginSkeletonTests
{
    // Minimal concrete PluginSkeleton for testing
    private sealed class TrackingPlugin : PluginSkeleton
    {
        public bool ExecuteInternalCalled { get; private set; }
        public IServiceProvider LastServiceProvider { get; private set; }
        public bool ShouldThrow { get; set; }

        public void SetTimeProvider(TimeProvider tp) => TimeProvider = tp;

        protected override void ExecuteInternal(IServiceProvider serviceProvider)
        {
            ExecuteInternalCalled = true;
            LastServiceProvider = serviceProvider;
            if (ShouldThrow) throw new InvalidOperationException("Intentional test failure");
        }
    }

    private static IServiceProvider BuildServiceProvider(Entity target = null)
    {
        var service = new FakeOrganizationService();
        var builder = new PluginExecutionContextBuilder(service);
        if (target != null) builder.WithTarget(target);
        return builder.BuildServiceProvider();
    }

    // ── Null guard ────────────────────────────────────────────────────────────

    [Test]
    public async Task Execute_WithNullServiceProvider_ThrowsArgumentNullException()
    {
        var plugin = new TrackingPlugin();
        var ex = await Assert.That(() => plugin.Execute(null)).ThrowsException();
        await Assert.That(ex).IsTypeOf<ArgumentNullException>();
    }

    // ── Happy path ────────────────────────────────────────────────────────────

    [Test]
    public async Task Execute_WithValidServiceProvider_CallsExecuteInternal()
    {
        var plugin = new TrackingPlugin();
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        plugin.Execute(sp);

        await Assert.That(plugin.ExecuteInternalCalled).IsTrue();
        await Assert.That(plugin.LastServiceProvider).IsNotNull();
    }

    // ── Exception propagation ─────────────────────────────────────────────────

    [Test]
    public async Task Execute_WhenExecuteInternalThrows_PropagatesException()
    {
        var plugin = new TrackingPlugin { ShouldThrow = true };
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        var ex = await Assert.That(() => plugin.Execute(sp)).ThrowsException();
        await Assert.That(ex).IsTypeOf<InvalidOperationException>();
    }

    // ── TimeProvider override ─────────────────────────────────────────────────

    [Test]
    public async Task TimeProvider_CanBeOverridden_ReturnsInjectedTime()
    {
        var fixedTime = new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var fakeTime = new FakeTimeProvider(fixedTime);
        var plugin = new TrackingPlugin();
        plugin.SetTimeProvider(fakeTime);

        await Assert.That(plugin.TimeProvider.GetUtcNow()).IsEqualTo(fixedTime);
    }

    [Test]
    public async Task TimeProvider_Default_IsSystemTimeProvider()
    {
        var plugin = new TrackingPlugin();

        await Assert.That(plugin.TimeProvider).IsEqualTo(TimeProvider.System);
    }
}
