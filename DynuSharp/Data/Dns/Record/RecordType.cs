using System.Runtime.Serialization;

namespace DynuSharp.Data.Dns.Record;
public enum RecordType
{
    [EnumMember(Value = "A")]
    A,
    [EnumMember(Value = "AAAA")]
    AAAA,
    [EnumMember(Value = "CAA")]
    CAA,
    [EnumMember(Value = "CNAME")]
    CNAME,
    [EnumMember(Value = "HINFO")]
    HINFO,
    [EnumMember(Value = "LOC")]
    LOC,
    [EnumMember(Value = "MX")]
    MX,
    [EnumMember(Value = "NS")]
    NS,
    [EnumMember(Value = "PTR")]
    PTR,
    [EnumMember(Value = "PF")]
    PF,
    [EnumMember(Value = "RP")]
    RP,
    [EnumMember(Value = "SOA")]
    SOA,
    [EnumMember(Value = "TXT")]
    TXT,
    [EnumMember(Value = "UF")]
    UF,
    [EnumMember(Value = "URI")]
    URI,
    [EnumMember(Value = "SRV")]
    SRV,
    [EnumMember(Value = "SPF")]
    SPF,
    [EnumMember(Value = "SSHFP")]
    SSHFP,
    [EnumMember(Value = "TLSA")]
    TLSA
}
