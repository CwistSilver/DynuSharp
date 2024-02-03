using System.Runtime.Serialization;

namespace DynuSharp.Data.Email;
public enum EmailType
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "EmailBackup")]
    EmailBackup,
    [EnumMember(Value = "EmailForward")]
    EmailForward,
    [EnumMember(Value = "EmailStoreForward")]
    EmailStoreForward,
    [EnumMember(Value = "FullServiceEmail")]
    FullServiceEmail,
    [EnumMember(Value = "SMTPOutboundRelay")]
    SMTPOutboundRelay
}