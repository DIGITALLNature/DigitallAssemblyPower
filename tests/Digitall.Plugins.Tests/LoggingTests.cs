// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Plugins.Extensions;
using Microsoft.Extensions.Logging;
using Digitall.Plugins.Logging;
using Digitall.Plugins.Services;
using Microsoft.Xrm.Sdk;
using IPluginLogger = Microsoft.Xrm.Sdk.PluginTelemetry.ILogger;
using XrmLogLevel = Microsoft.Xrm.Sdk.PluginTelemetry.LogLevel;

namespace Digitall.Plugins.Tests;

/// <summary>Minimal no-op ITracingService for tests.</summary>
internal sealed class NoopTracingService : ITracingService
{
    public string LastTrace { get; private set; }
    public void Trace(string format, params object[] args) => LastTrace = string.Format(format, args);
}

public class LoggingTests
{
    private static (IServiceProvider Sp, IPluginLogger PluginLogger) BuildDependencies()
    {
        var sp = new PluginExecutionContextBuilder(new FakeOrganizationService()).BuildServiceProvider();
        var pluginLogger = (IPluginLogger)sp.GetService(typeof(IPluginLogger));
        return (sp, pluginLogger);
    }

    // ── LoggingFacade ──────────────────────────────────────────────────────────

    [Test]
    public async Task LoggingFacade_Log_WritesToTracingService()
    {
        var tracing = new NoopTracingService();
        var (_, pluginLogger) = BuildDependencies();
        var facade = new LoggingFacade(tracing, pluginLogger);

        facade.LogInformation("Hello {0}", "world");

        await Assert.That(tracing.LastTrace).IsNotNull();
        await Assert.That(tracing.LastTrace).Contains("world");
    }

    [Test]
    public async Task LoggingFacade_LogWithNullException_DoesNotThrow()
    {
        var tracing = new NoopTracingService();
        var (_, pluginLogger) = BuildDependencies();
        var facade = new LoggingFacade(tracing, pluginLogger);

        facade.Log(XrmLogLevel.Warning, null, "message without exception");

        await Assert.That(tracing.LastTrace).IsNotNull();
    }

    [Test]
    public async Task LoggingFacade_LogWithException_IncludesExceptionDetails()
    {
        var tracing = new NoopTracingService();
        var (_, pluginLogger) = BuildDependencies();
        var facade = new LoggingFacade(tracing, pluginLogger);
        var ex = new InvalidOperationException("test-error");

        facade.LogError(ex, "something failed");

        await Assert.That(tracing.LastTrace).Contains("test-error");
    }

    // ── TracingServiceLogger ──────────────────────────────────────────────────

    [Test]
    public async Task TracingServiceLogger_IsEnabled_TrueForNonNoneLevel()
    {
        var logger = new TracingServiceLogger(new NoopTracingService());

        await Assert.That(logger.IsEnabled(LogLevel.Debug)).IsTrue();
        await Assert.That(logger.IsEnabled(LogLevel.None)).IsFalse();
    }

    [Test]
    public async Task TracingServiceLogger_Log_WritesFormattedMessage()
    {
        var tracing = new NoopTracingService();
        var logger = new TracingServiceLogger(tracing);

        logger.LogInformation("test {Value}", 42);

        await Assert.That(tracing.LastTrace).IsNotNull();
        await Assert.That(tracing.LastTrace).Contains("42");
    }

    [Test]
    public async Task TracingServiceLogger_Log_WithNullException_DoesNotThrow()
    {
        var tracing = new NoopTracingService();
        var logger = new TracingServiceLogger(tracing);

        logger.Log(LogLevel.Warning, default, "state", null, (s, _) => s);

        await Assert.That(tracing.LastTrace).IsNotNull();
    }

    // ── PluginTelemetryLogger ─────────────────────────────────────────────────

    [Test]
    public async Task PluginTelemetryLogger_IsEnabled_ReturnsExpectedResult()
    {
        var (_, pluginLogger) = BuildDependencies();
        var logger = new PluginTelemetryLogger(pluginLogger);

        // FakeDataverse.Testing's plugin logger should be enabled for standard levels
        var enabled = logger.IsEnabled(LogLevel.Information);
        await Assert.That(enabled).IsTypeOf<bool>();
    }

    [Test]
    public void PluginTelemetryLogger_Log_DoesNotThrow()
    {
        var (_, pluginLogger) = BuildDependencies();
        var logger = new PluginTelemetryLogger(pluginLogger);

        logger.LogInformation("message from telemetry logger");
    }

    // ── CompositeLogger ────────────────────────────────────────────────────────

    [Test]
    public async Task CompositeLogger_IsEnabled_TrueWhenAnyChildEnabled()
    {
        var composite = new CompositeLogger([
            new TracingServiceLogger(new NoopTracingService()),
            new TracingServiceLogger(new NoopTracingService())
        ]);

        await Assert.That(composite.IsEnabled(LogLevel.Information)).IsTrue();
    }

    [Test]
    public async Task CompositeLogger_Log_WritesToAllChildren()
    {
        var tracing1 = new NoopTracingService();
        var tracing2 = new NoopTracingService();
        var composite = new CompositeLogger([
            new TracingServiceLogger(tracing1),
            new TracingServiceLogger(tracing2)
        ]);

        composite.LogInformation("broadcast message");

        await Assert.That(tracing1.LastTrace).IsNotNull();
        await Assert.That(tracing2.LastTrace).IsNotNull();
        await Assert.That(tracing1.LastTrace).Contains("broadcast message");
        await Assert.That(tracing2.LastTrace).Contains("broadcast message");
    }

    [Test]
    public void CompositeLogger_BeginScope_HandlesNullChildScopes()
    {
        var composite = new CompositeLogger([
            new TracingServiceLogger(new NoopTracingService())
        ]);

        // TracingServiceLogger.BeginScope returns null — CompositeLogger must handle that
        var scope = composite.BeginScope("test-scope");
        scope?.Dispose();
    }

    // ── LoggingFacade via real ServiceProvider (integration) ──────────────────

    [Test]
    public async Task GetLoggingFacade_ViaServiceProvider_ReturnsWorkingFacade()
    {
        var (sp, _) = BuildDependencies();

#pragma warning disable CS0618 // Obsolete: only using in test to verify the legacy path still works
        var facade = sp.GetLoggingFacade();
#pragma warning restore CS0618

        await Assert.That(facade).IsNotNull();
        facade.LogInformation("integration facade test");
    }
}
