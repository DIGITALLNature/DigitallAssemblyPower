// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Diagnostics;
using Digitall.Plugins.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;

namespace Digitall.Plugins;

public abstract partial class PluginSkeleton : IPlugin
{
    /// <summary>
    /// Executes the plugin using the provided service provider.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public void Execute(IServiceProvider serviceProvider)
    {
        if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
        // Get the logger from the service provider
        var logger = serviceProvider.GetLogger(ServiceProviderExtensions.LogSink.PluginTelemetry, ServiceProviderExtensions.LogSink.TracingService);

        // Start a stopwatch to measure execution time
        var stopwatch = Stopwatch.StartNew();

        try
        {
            // Get the execution context from the service provider
            var executionContext = serviceProvider.GetExecutionContext();

            // Log the start of the execution
            LogExecutionStart(logger, GetType().FullName, executionContext.MessageName, executionContext.GetFormattedExecutionStage(), executionContext.GetFormattedExecutionMode());

            // Execute the plugin's internal logic
            ExecuteInternal(serviceProvider);
        }
        catch (Exception exception)
        {
            // Log any exceptions that occur during execution
            LogExecutionFailed(logger, exception);
            throw;
        }
        finally
        {
            // Log the end of the execution and the elapsed time
            LogExecutionEnd(logger, stopwatch.ElapsedMilliseconds);
        }
    }

    protected abstract void ExecuteInternal(IServiceProvider serviceProvider);

    [LoggerMessage(LogLevel.Information, "Execution started {PluginType}: Message {MessageName} - Stage {ExecutionStage} - Mode {ExecutionMode}")]
    private static partial void LogExecutionStart(ILogger logger, string pluginType, string messageName, string executionStage, string executionMode);

    [LoggerMessage(LogLevel.Error, "Execution failed")]
    private static partial void LogExecutionFailed(ILogger logger, Exception exception);

    [LoggerMessage(LogLevel.Information, "Execution finished in {ElapsedMilliseconds} ms")]
    private static partial void LogExecutionEnd(ILogger logger, long elapsedMilliseconds);
}