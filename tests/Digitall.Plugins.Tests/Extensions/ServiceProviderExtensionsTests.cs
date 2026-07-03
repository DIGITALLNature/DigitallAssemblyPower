// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Plugins.Extensions;
using Digitall.Plugins.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;

namespace Digitall.Plugins.Tests.Extensions;

public class ServiceProviderExtensionsTests
{
    private static IServiceProvider BuildServiceProvider()
    {
        return new PluginExecutionContextBuilder(new FakeOrganizationService()).BuildServiceProvider();
    }

    // ── GetLogger (plugin telemetry) ──────────────────────────────────────────

    [Test]
    public async Task GetLogger_NoSinks_ReturnsTracingServiceLogger()
    {
        var logger = BuildServiceProvider().GetLogger();

        await Assert.That(logger).IsNotNull();
    }

    // ── GetLogger (ILogger with sinks) ────────────────────────────────────────

    [Test]
    public async Task GetLogger_WithTracingServiceSink_ReturnsLogger()
    {
        var logger = BuildServiceProvider().GetLogger(ServiceProviderExtensions.LogSink.TracingService);

        await Assert.That(logger).IsNotNull();
        await Assert.That(logger.IsEnabled(LogLevel.Information)).IsTrue();
    }

    [Test]
    public async Task GetLogger_WithPluginTelemetrySink_ReturnsLogger()
    {
        var logger = BuildServiceProvider().GetLogger(ServiceProviderExtensions.LogSink.PluginTelemetry);

        await Assert.That(logger).IsNotNull();
    }

    [Test]
    public async Task GetLogger_WithBothSinks_ReturnsCompositeLogger()
    {
        var logger = BuildServiceProvider().GetLogger(
            ServiceProviderExtensions.LogSink.PluginTelemetry,
            ServiceProviderExtensions.LogSink.TracingService);

        await Assert.That(logger).IsNotNull();
        // Composite: logs to both — should not throw
        logger.LogInformation("test message");
    }

    [Test]
    public async Task GetLogger_EmptySinks_FallsBackToTracingService()
    {
        var logger = BuildServiceProvider().GetLogger([]);

        await Assert.That(logger).IsNotNull();
    }

    [Test]
    public async Task GetLogger_NullSinks_ThrowsArgumentNullException()
    {
        var ex = await Assert.That(() => _ = BuildServiceProvider().GetLogger(null)).ThrowsException();
        await Assert.That(ex).IsTypeOf<ArgumentNullException>();
    }

    // ── GetTimeProvider ───────────────────────────────────────────────────────

    [Test]
    public async Task GetTimeProvider_WhenNotRegistered_ReturnsSystemTimeProvider()
    {
        var timeProvider = BuildServiceProvider().GetTimeProvider();

        await Assert.That(timeProvider).IsEqualTo(TimeProvider.System);
    }

    [Test]
    public async Task GetTimeProvider_WhenFakeTimeProviderRegistered_ReturnsFake()
    {
        var service = new FakeOrganizationService();
        var sp = new PluginExecutionContextBuilder(service).BuildServiceProvider();

        var timeProvider = sp.GetTimeProvider();
        await Assert.That(timeProvider).IsNotNull();
    }

    // ── GetSerializerService ──────────────────────────────────────────────────

    [Test]
    public async Task GetSerializerService_ReturnsNewSerializerServiceInstance()
    {
        var serializer = BuildServiceProvider().GetSerializerService();

        await Assert.That(serializer).IsNotNull();
        await Assert.That(serializer).IsTypeOf<SerializerService>();
    }

    // ── GetExecutionContext ───────────────────────────────────────────────────

    [Test]
    public async Task GetExecutionContext_ReturnsPluginExecutionContext()
    {
        var ctx = BuildServiceProvider().GetExecutionContext();

        await Assert.That(ctx).IsNotNull();
    }

    // ── GetOrganizationService / GetElevatedOrganizationService ──────────────

    [Test]
    public async Task GetOrganizationService_ReturnsNonNullService()
    {
        var svc = BuildServiceProvider().GetOrganizationService();

        await Assert.That(svc).IsNotNull();
    }

    [Test]
    public async Task GetElevatedOrganizationService_ReturnsNonNullService()
    {
        var svc = BuildServiceProvider().GetElevatedOrganizationService();

        await Assert.That(svc).IsNotNull();
    }

    // ── RegisterProxyTypesAssembly ────────────────────────────────────────────

    [Test]
    public async Task RegisterProxyTypesAssembly_WhenPropertyMissing_ReturnsSameServiceProviderWithoutThrowing()
    {
        var sp = BuildServiceProvider();

        var result = sp.RegisterProxyTypesAssembly(typeof(ServiceProviderExtensionsTests).Assembly);

        await Assert.That(result).IsEqualTo(sp);
    }

    [Test]
    public async Task RegisterProxyTypesAssembly_WhenPropertyExists_SetsProxyTypesAssembly()
    {
        var factory = new ProxyTypesAssemblyFactory();
        var sp = new SingleServiceProvider(typeof(IOrganizationServiceFactory), factory);
        var expected = typeof(ServiceProviderExtensionsTests).Assembly;

        var result = sp.RegisterProxyTypesAssembly(expected);

        await Assert.That(result).IsEqualTo((IServiceProvider)sp);
        await Assert.That(factory.ProxyTypesAssembly).IsEqualTo(expected);
    }

    // Minimal IServiceProvider returning a single registered service.
    private sealed class SingleServiceProvider(Type serviceType, object instance) : IServiceProvider
    {
        public object GetService(Type serviceType1) =>
            serviceType1 == serviceType ? instance : null;
    }

    // Fake factory exposing a non-public ProxyTypesAssembly property, mirroring the
    // Dataverse runtime factory that RegisterProxyTypesAssembly targets via reflection.
    private sealed class ProxyTypesAssemblyFactory : IOrganizationServiceFactory
    {
        [SuppressMessage("Major Code Smell", "S3459", Justification = "Set via reflection by RegisterProxyTypesAssembly.")]
        [SuppressMessage("Major Code Smell", "S1144", Justification = "Setter is invoked via reflection by RegisterProxyTypesAssembly.")]
        internal Assembly ProxyTypesAssembly { get; private set; }

        public IOrganizationService CreateOrganizationService(Guid? userId) => null;
    }
}
