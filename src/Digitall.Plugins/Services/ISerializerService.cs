// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

// ReSharper disable UnusedMemberInSuper.Global

namespace Digitall.Plugins.Services;

/// <summary>
///     Json SerializerService Interface
/// </summary>
public interface ISerializerService
{
    /// <summary>
    ///     Convert Object to Json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    string JsonSerialize<T>(T data);

    /// <summary>
    ///     Convert Json to Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json">JSON string</param>
    /// <returns></returns>
    T JsonDeserialize<T>(string json);
}
