﻿using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class FolderResponse : ISharepointPayload
    {
        [DataMember(Name = "Exists")] public bool Exists { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "ServerRelativeUrl")]
        public string ServerRelativeUrl { get; set; }

        [DataMember(Name = "UniqueId")] public string UniqueId { get; set; }
    }
}
