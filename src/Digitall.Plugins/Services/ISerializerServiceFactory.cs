// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

namespace Digitall.Plugins.Services;

/// <summary>
/// Creates an <see cref="ISerializerService"/> implementation.
/// </summary>
public interface ISerializerServiceFactory
{
    /// <summary>
    /// Creates a serializer service using the factory's configuration.
    /// </summary>
    /// <returns>The configured serializer service.</returns>
    ISerializerService CreateSerializerService();
}
