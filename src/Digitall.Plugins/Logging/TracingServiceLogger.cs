// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;

namespace Digitall.Plugins.Logging;

internal sealed class TracingServiceLogger(ITracingService tracingService) : ILogger
{
    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var message = formatter(state, exception);
        tracingService.Trace($"[{logLevel}] {message}");

        if (exception != null) tracingService.Trace(exception.ToString());
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => NoopDisposable.Instance;
}
