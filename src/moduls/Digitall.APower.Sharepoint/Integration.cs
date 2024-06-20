// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Digitall.APower.Sharepoint.Contracts;
using Microsoft.Xrm.Sdk;

namespace Digitall.APower.Sharepoint
{
    public static class Integration
    {
        public static ISharepointService CreateSharePointService(this Executor executor) => executor.ServiceProvider.CreateSharePointService();

        public static ISharepointService CreateSharePointService(this IServiceProvider pluginCore) => new SharepointService(pluginCore);
    }
}
