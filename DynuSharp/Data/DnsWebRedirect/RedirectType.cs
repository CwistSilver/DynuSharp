using System.Runtime.Serialization;

namespace DynuSharp.Data.DnsWebRedirect;
public enum RedirectType
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "PF")]
    PF,
    [EnumMember(Value = "UF")]
    UF
}
