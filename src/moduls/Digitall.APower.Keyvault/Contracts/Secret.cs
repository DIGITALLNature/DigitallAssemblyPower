// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Runtime.Serialization;

namespace Digitall.APower.Keyvault.Contracts
{
    /*
       {
         "value": "mysecretvalue",
         "id": "https://kv-sdk-test.vault-int.azure-int.net/secrets/mysecretname/4387e9f3d6e14c459867679a90fd0f79",
         "attributes": {
           "enabled": true,
           "created": 1493938410,
           "updated": 1493938410,
           "recoverylevel": "Recoverable+Purgeable"
         }
       }
       */
    [DataContract]
    public class Secret
    {
        [DataMember(Name = "value")] public string Value { get; set; }

        [DataMember(Name = "attributes")] public SecretAttributes Attributes { get; set; }
    }

    [DataContract]
    public class SecretAttributes
    {
        [DataMember(Name = "enabled")] public bool Enabled { get; set; }

        [DataMember(Name = "created")] public int Created { get; set; }

        [DataMember(Name = "updated")] public int Updated { get; set; }

        [DataMember(Name = "exp")] public int Expiry { get; set; }

        [DataMember(Name = "nbf")] public int NotBefore { get; set; }

        [DataMember(Name = "recoverylevel")] public string Recoverylevel { get; set; }
    }
}
