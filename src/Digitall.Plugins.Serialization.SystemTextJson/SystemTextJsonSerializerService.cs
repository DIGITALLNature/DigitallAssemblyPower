// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Text.Json;
using Digitall.Plugins.Services;

namespace Digitall.Plugins.Serialization.SystemTextJson;

internal sealed class SystemTextJsonSerializerService(JsonSerializerOptions options) : ISerializerService
{
    public string JsonSerialize<T>(T data)
    {
        if (data is null) return null;

        return JsonSerializer.Serialize(data, options);
    }

    public T JsonDeserialize<T>(string json)
    {
        if (json == null) return default;

        return JsonSerializer.Deserialize<T>(json, options);
    }
}
