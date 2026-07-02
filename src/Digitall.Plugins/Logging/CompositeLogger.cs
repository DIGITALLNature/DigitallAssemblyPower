// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Digitall.Plugins.Logging;

internal sealed class CompositeLogger(IReadOnlyList<ILogger> loggers) : ILogger
{
    public bool IsEnabled(LogLevel logLevel) => loggers.Any(l => l.IsEnabled(logLevel));

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        foreach (var logger in loggers.Where(l => l.IsEnabled(logLevel)))
        {
            logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        var scopes = loggers.Select(l => l.BeginScope(state)).Where(s => s != null).ToList();

        return scopes.Count == 0 ? NoopDisposable.Instance : new CompositeDisposable(scopes);
    }

    private sealed class CompositeDisposable(IList<IDisposable> disposables) : IDisposable
    {
        public void Dispose()
        {
            foreach (var d in disposables)
            {
                d.Dispose();
            }
        }
    }
}
