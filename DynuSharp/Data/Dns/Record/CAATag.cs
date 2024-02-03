using System.Runtime.Serialization;

namespace DynuSharp.Data.Dns.Record;
public enum CAATag
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "issue")]
    issue,
    [EnumMember(Value = "issuewild")]
    issuewild,
    [EnumMember(Value = "iodef")]
    iodef
}
