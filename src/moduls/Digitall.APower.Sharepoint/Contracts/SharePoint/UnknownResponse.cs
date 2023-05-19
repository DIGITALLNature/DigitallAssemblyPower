using System.Collections.Generic;

namespace Digitall.APower.Sharepoint.Contracts.SharePoint
{
    public class UnknownResponse : ISharepointPayload
    {
        public Dictionary<string, object> Content { get; set; }
    }
}
