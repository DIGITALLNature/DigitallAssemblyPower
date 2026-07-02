// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.PluginTelemetry;

namespace Digitall.Plugins.Services;

public class LoggingFacade(ITracingService tracingService, ILogger logger) : ILoggingFacade
{
    public void Log(LogLevel logLevel, string message, params object[] args)
    {
        tracingService.Trace($"{logLevel}: {message}", args);
        logger.Log(logLevel, message, args);
    }

    public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
    {
        var exceptionInfo = exception != null
            ? $"{Environment.NewLine}{exception}{Environment.NewLine}{exception.StackTrace}"
            : string.Empty;
        tracingService.Trace($"{logLevel}: {message}{exceptionInfo}", args);
        logger.Log(logLevel, exception, message, args);
    }

    public void LogTrace(string message, params object[] args) => Log(LogLevel.Trace, message, args);
    public void LogDebug(string message, params object[] args) => Log(LogLevel.Debug, message, args);
    public void LogInformation(string message, params object[] args) => Log(LogLevel.Information, message, args);
    public void LogWarning(string message, params object[] args) => Log(LogLevel.Warning, message, args);

    public void LogWarning(Exception exception, string message, params object[] args) => Log(LogLevel.Warning, exception, message, args);

    public void LogError(string message, params object[] args) => Log(LogLevel.Error, message, args);

    public void LogError(Exception exception, string message, params object[] args) => Log(LogLevel.Error, exception, message, args);

    public void LogCritical(string message, params object[] args) => Log(LogLevel.Critical, message, args);

    public void LogCritical(Exception exception, string message, params object[] args) => Log(LogLevel.Critical, exception, message, args);
}
