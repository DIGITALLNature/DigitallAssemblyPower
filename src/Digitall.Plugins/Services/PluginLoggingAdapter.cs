// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Extensions.Logging;
using IPluginLogger = Microsoft.Xrm.Sdk.PluginTelemetry.ILogger;

namespace Digitall.Plugins.Services;

internal sealed class PluginLoggingAdapter<TPlugin>(IPluginLogger logger) : ILogger<TPlugin>
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        logger.Log(logLevel.ToPluginLogLevel(), eventId.ToPluginEventId(), state, exception, formatter);
    }

    public bool IsEnabled(LogLevel logLevel) => logger.IsEnabled(logLevel.ToPluginLogLevel());

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => logger.BeginScope(state);
}
