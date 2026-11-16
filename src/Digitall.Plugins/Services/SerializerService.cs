// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

// ReSharper disable MemberCanBePrivate.Global
namespace Digitall.Plugins.Services;

public sealed class SerializerService : ISerializerService
{
    private readonly bool _tidy;

    public SerializerService(DataContractJsonSerializerSettings settings = null, bool tidy = false)
    {
        Settings = settings ?? new DataContractJsonSerializerSettings
        {
            UseSimpleDictionaryFormat = true,
            DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ssZ")
        };
        _tidy = tidy;
    }

    public DataContractJsonSerializerSettings Settings { get; }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
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
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <param name="settings"></param>
    /// <param name="tidy"></param>
    /// <returns></returns>
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