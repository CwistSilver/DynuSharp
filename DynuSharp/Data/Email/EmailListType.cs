using System.Runtime.Serialization;

namespace DynuSharp.Data.Email;
public enum EmailListType
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "EmailAddress")]
    EmailAddress,
    [EnumMember(Value = "Domain")]
    Domain,
    [EnumMember(Value = "IPAddress")]
    IPAddress
}
