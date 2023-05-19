using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class ListItemAllFieldsResponse : ISharepointPayload
    {
        [DataMember(Name = "odata.null")] public bool ODataNull { get; set; }

        [DataMember(Name = "GUID")] public string Id { get; set; }
    }
}
