// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Extensions.Logging;
using IPluginLogger = Microsoft.Xrm.Sdk.PluginTelemetry.ILogger;
using PluginEventId = Microsoft.Xrm.Sdk.PluginTelemetry.EventId;
using PluginLogLevel = Microsoft.Xrm.Sdk.PluginTelemetry.LogLevel;

namespace Digitall.Plugins.Logging;

internal sealed class PluginTelemetryLogger(IPluginLogger logger) : ILogger
{
    public bool IsEnabled(LogLevel logLevel) => logger.IsEnabled(MapLogLevel(logLevel));

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        logger.Log(MapLogLevel(logLevel), MapEventId(eventId), state, exception, formatter);
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => logger.BeginScope(state);

    private static PluginLogLevel MapLogLevel(LogLevel logLevel) =>
        logLevel switch
        {
            LogLevel.Trace => PluginLogLevel.Trace,
            LogLevel.Debug => PluginLogLevel.Debug,
            LogLevel.Information => PluginLogLevel.Information,
            LogLevel.Warning => PluginLogLevel.Warning,
            LogLevel.Error => PluginLogLevel.Error,
            LogLevel.Critical => PluginLogLevel.Critical,
            _ => PluginLogLevel.None
        };

    private static PluginEventId MapEventId(EventId eventId) => new(eventId.Id, eventId.Name);
}
