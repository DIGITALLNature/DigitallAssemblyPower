// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Runtime.Serialization.Json;

namespace Digitall.APower.Contracts
{
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
        /// <param name="settings">optional DataContractJsonSerializerSettings; otherwise using this as default UseSimpleDictionaryFormat = true, DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ"</param>
        /// <returns></returns>
        string JsonSerialize<T>(object data, DataContractJsonSerializerSettings settings = default);

        /// <summary>
        ///     Convert Json to Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">JSON string</param>
        /// <param name="settings">optional DataContractJsonSerializerSettings; otherwise using this as default UseSimpleDictionaryFormat = true, DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ".</param>
        /// <param name="tidy">Optional. Set it to true to convert empty string attribute values to null.</param>
        /// <returns></returns>
        T JsonDeserialize<T>(string json, DataContractJsonSerializerSettings settings = default, bool tidy = false);
    }
}
