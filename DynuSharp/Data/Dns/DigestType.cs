using System.Runtime.Serialization;

namespace DynuSharp.Data.Dns;
public enum DigestType
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "Sha1")]
    Sha1,
    [EnumMember(Value = "Sha256")]
    Sha256,
    [EnumMember(Value = "EccGost")]
    EccGost,
    [EnumMember(Value = "Sha384")]
    Sha384
}