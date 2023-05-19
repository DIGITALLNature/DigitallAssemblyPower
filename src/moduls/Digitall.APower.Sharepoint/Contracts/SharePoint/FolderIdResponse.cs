using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class FolderIdResponse : ISharepointPayload
    {
        [DataMember(Name = "value")] public int Value { get; set; }
    }
}
