// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Text.Json;
using Digitall.Plugins.Services;

namespace Digitall.Plugins.Serialization.SystemTextJson;

/// <summary>
/// Creates a serializer service backed by <see cref="JsonSerializer"/>.
/// </summary>
public sealed class SystemTextJsonSerializerServiceFactory : ISerializerServiceFactory
{
    private readonly JsonSerializerOptions _options;

    /// <summary>
    /// Initializes a factory for the System.Text.Json serializer.
    /// </summary>
    /// <param name="options">Optional JSON serializer options.</param>
    public SystemTextJsonSerializerServiceFactory(JsonSerializerOptions options = null)
    {
        _options = options == null ? new JsonSerializerOptions() : new JsonSerializerOptions(options);
    }

    /// <inheritdoc />
    public ISerializerService CreateSerializerService() => new SystemTextJsonSerializerService(_options);
}
