// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;

namespace Digitall.Plugins.Logging;

/// <summary>
/// A no-op <see cref="IDisposable"/> singleton used as a safe return value for
/// <see cref="Microsoft.Extensions.Logging.ILogger.BeginScope{TState}"/> implementations
/// that do not support scoping.
/// </summary>
internal sealed class NoopDisposable : IDisposable
{
    public static readonly NoopDisposable Instance = new();

    private NoopDisposable() { }

    public void Dispose() { }
}
