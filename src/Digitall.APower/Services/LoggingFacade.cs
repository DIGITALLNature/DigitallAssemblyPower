using System;
using Digitall.APower.Contracts;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.PluginTelemetry;

namespace Digitall.APower.Services;

[Obsolete("Use Microsoft.Extensions.Logging.ILogger instead. You can retrieve an ILogger from the service provider where you can specify the log sinks.")]
public class LoggingFacade(ITracingService tracingService, ILogger logger) : ILoggingFacade
{
    public void Log(LogLevel logLevel, string message, params object[] @params)
    {
        tracingService.Trace($"{logLevel}: {message}", @params);
        logger.Log(logLevel, message, @params);
    }

    public void Log(LogLevel logLevel, Exception exception, string message, params object[] @params)
    {
        tracingService.Trace($"{logLevel}: {message}{Environment.NewLine}{exception}{Environment.NewLine}{exception.StackTrace}", @params);
        logger.Log(logLevel, exception, message, @params);
    }

    public void LogTrace(string message, params object[] @params) => Log(LogLevel.Trace, message, @params);
    public void LogDebug(string message, params object[] @params) => Log(LogLevel.Debug, message, @params);
    public void LogInformation(string message, params object[] @params) => Log(LogLevel.Information, message, @params);
    public void LogWarning(string message, params object[] @params) => Log(LogLevel.Warning, message, @params);

    public void LogWarning(Exception exception, string message, params object[] @params) => Log(LogLevel.Warning, exception, message, @params);

    public void LogError(string message, params object[] @params) => Log(LogLevel.Error, message, @params);

    public void LogError(Exception exception, string message, params object[] @params) => Log(LogLevel.Error, exception, message, @params);

    public void LogCritical(string message, params object[] @params) => Log(LogLevel.Critical, message, @params);

    public void LogCritical(Exception exception, string message, params object[] @params) => Log(LogLevel.Critical, exception, message, @params);
}
