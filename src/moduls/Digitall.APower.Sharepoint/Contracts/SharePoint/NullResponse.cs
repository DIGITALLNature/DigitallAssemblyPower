using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class NullResponse : ISharepointPayload
    {
        [DataMember(Name = "odata.null")] public bool ODataNull { get; set; }
    }
}
