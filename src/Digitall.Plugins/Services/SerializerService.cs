// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

// ReSharper disable MemberCanBePrivate.Global
namespace Digitall.Plugins.Services;

public sealed class SerializerService(
    DataContractJsonSerializerSettings settings = null,
    bool tidy = false) : ISerializerService
{
    private readonly bool _tidy = tidy;

    public DataContractJsonSerializerSettings Settings { get; } = settings ?? new DataContractJsonSerializerSettings
        {
            UseSimpleDictionaryFormat = true,
            DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssZ")
        };

    /// <summary>
    /// Serializes a value as JSON using the configured DataContract serializer.
    /// </summary>
    /// <typeparam name="T">The type of the value to serialize.</typeparam>
    /// <param name="data">The value to serialize.</param>
    /// <returns>The serialized JSON, or <see langword="null"/> when <paramref name="data"/> is null.</returns>
    public string JsonSerialize<T>(T data)
    {
        if (data is null)
        {
            return null;
        }

        using var ms = new MemoryStream();
        new DataContractJsonSerializer(typeof(T), Settings).WriteObject(ms, data);
        var json = ms.ToArray();
        return Encoding.UTF8.GetString(json, 0, json.Length);
    }

    /// <summary>
    /// Deserializes JSON using the configured DataContract serializer.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="json">The JSON to deserialize.</param>
    /// <returns>The deserialized value, or the default value when <paramref name="json"/> is null.</returns>
    public T JsonDeserialize<T>(string json)
    {
        if (json == null)
        {
            return default;
        }

        var cleanJson = !_tidy ? json : json.Replace("\"\"", "null");

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(cleanJson));
        return (T)new DataContractJsonSerializer(typeof(T), Settings).ReadObject(ms);
    }
}