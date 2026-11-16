// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Runtime.Serialization.Json;

namespace Digitall.Plugins.Services;

/// <summary>
/// Creates a serializer service backed by <see cref="DataContractJsonSerializer"/>.
/// </summary>
public sealed class DataContractSerializerServiceFactory : ISerializerServiceFactory
{
    private readonly DataContractJsonSerializerSettings _settings;
    private readonly bool _tidy;

    /// <summary>
    /// Initializes a factory for the DataContract JSON serializer.
    /// </summary>
    /// <param name="settings">Optional DataContract serializer settings.</param>
    /// <param name="tidy">Whether to replace empty JSON strings with null during deserialization.</param>
    public DataContractSerializerServiceFactory(DataContractJsonSerializerSettings settings = null, bool tidy = false)
    {
        _settings = settings;
        _tidy = tidy;
    }

    /// <inheritdoc />
    public ISerializerService CreateSerializerService() => new SerializerService(_settings, _tidy);
}
