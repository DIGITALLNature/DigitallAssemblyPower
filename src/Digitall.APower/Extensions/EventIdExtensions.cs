// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using Microsoft.Extensions.Logging;
using PluginEventId = Microsoft.Xrm.Sdk.PluginTelemetry.EventId;

namespace Digitall.APower;

public static class EventIdExtensions
{
    extension(EventId eventId)
    {
        public PluginEventId ToPluginEventId() => new(eventId.Id, eventId.Name);
    }
}
