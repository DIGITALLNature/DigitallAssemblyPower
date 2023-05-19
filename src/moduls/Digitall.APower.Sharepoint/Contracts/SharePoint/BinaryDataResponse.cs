using System.IO;
using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class BinaryDataResponse : ISharepointPayload
    {
        [DataMember(Name = "Stream")] public MemoryStream Stream { get; set; }
    }
}
