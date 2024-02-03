using System.Runtime.Serialization;

namespace DynuSharp.Data.Dns;
public enum UpdateStatus
{
    [EnumMember(Value = "Good")]
    Good,

    [EnumMember(Value = "Bad Authentication")]
    BadAuthentication,

    [EnumMember(Value = "DNS Error")]
    DNSError,

    [EnumMember(Value = "Server Error")]
    ServerError,

    [EnumMember(Value = "911")]
    _911,

    [EnumMember(Value = "Not Fully Qualified Domain Name")]
    NotFullyQualifiedDomainName,

    [EnumMember(Value = "No Change")]
    NoChange,

    [EnumMember(Value = "Abuse")]
    Abuse,

    [EnumMember(Value = "No Host")]
    NoHost,

    [EnumMember(Value = "Too Many Hosts")]
    TooManyHosts,

    [EnumMember(Value = "Not Member")]
    NotMember,

    [EnumMember(Value = "Old Version")]
    OldVersion,

    [EnumMember(Value = "Unknown")]
    Unknown
}

