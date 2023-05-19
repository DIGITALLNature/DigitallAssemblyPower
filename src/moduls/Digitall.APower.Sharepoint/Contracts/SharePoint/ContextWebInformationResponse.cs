using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class ContextWebInformationResponse : ISharepointPayload
    {
        [DataMember(Name = "FormDigestValue")] public string FormDigestValue { get; set; }

        [DataMember(Name = "LibraryVersion")] public string LibraryVersion { get; set; }

        [DataMember(Name = "SiteFullUrl")] public string SiteFullUrl { get; set; }

        [DataMember(Name = "WebFullUrl")] public string WebFullUrl { get; set; }
    }
}
