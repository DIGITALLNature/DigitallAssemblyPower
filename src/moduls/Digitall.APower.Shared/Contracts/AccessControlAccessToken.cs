// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Runtime.Serialization;

namespace dgt.apower.http.Contract
{
    [DataContract]
    public class AccessControlAccessToken
    {
        [DataMember(Name = "token_type")] public string TokenType { get; set; }

        [DataMember(Name = "expires_in")] public int ExpiresIn { get; set; }

        [DataMember(Name = "not_before")] public int NotBefore { get; set; }

        [DataMember(Name = "expires_on")] public int ExpiresOn { get; set; }

        [DataMember(Name = "resource")] public string Resource { get; set; }

        [DataMember(Name = "access_token")] public string AccessToken { get; set; }
    }
}
