// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Extensions.Logging;
using PluginLogLevel = Microsoft.Xrm.Sdk.PluginTelemetry.LogLevel;

namespace Digitall.Plugins;

public static class LogLevelExtensions
{
    extension(LogLevel logLevel)
    {
        public PluginLogLevel ToPluginLogLevel() =>
            logLevel switch
            {
                LogLevel.Trace => PluginLogLevel.Trace,
                LogLevel.Debug => PluginLogLevel.Debug,
                LogLevel.Information => PluginLogLevel.Information,
                LogLevel.Warning => PluginLogLevel.Warning,
                LogLevel.Error => PluginLogLevel.Error,
                LogLevel.Critical => PluginLogLevel.Critical,
                LogLevel.None => PluginLogLevel.None,
                _ => throw new InvalidOperationException($"Invalid log level: {logLevel}")
            };
    }
}
