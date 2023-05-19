// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using Digitall.APower.Sharepoint.Contracts;

namespace Digitall.APower.Sharepoint
{
    public static class Integration
    {
        public static ISharepointService CreateSharePointService(this Executor executor) => executor.Core.CreateSharePointService();

        public static ISharepointService CreateSharePointService(this PluginCore pluginCore) => new SharepointService(pluginCore);
    }
}
