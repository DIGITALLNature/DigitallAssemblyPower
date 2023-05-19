using System.Runtime.Serialization;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    [DataContract]
    public class ListItemEntityTypeResponse : ISharepointPayload
    {
        [DataMember(Name = "ListItemEntityTypeFullName")]
        public string ListItemEntityTypeFullName { get; set; }
    }
}
