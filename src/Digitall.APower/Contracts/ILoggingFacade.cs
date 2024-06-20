using System;
using Microsoft.Xrm.Sdk.PluginTelemetry;

#pragma warning disable CA1716
namespace Digitall.APower.Contracts
{
    public interface ILoggingFacade
    {
        void Log(LogLevel logLevel, string message, params object[] @params);
        void Log(LogLevel logLevel, Exception exception, string message, params object[] @params);
        void LogTrace(string message, params object[] @params);
        void LogDebug(string message, params object[] @params);
        void LogInformation(string message, params object[] @params);
        void LogWarning(string message, params object[] @params);
        void LogWarning(Exception exception, string message, params object[] @params);
        void LogError(string message, params object[] @params);
        void LogError(Exception exception, string message, params object[] @params);
        void LogCritical(string message, params object[] @params);
        void LogCritical(Exception exception, string message, params object[] @params);
    }
}
