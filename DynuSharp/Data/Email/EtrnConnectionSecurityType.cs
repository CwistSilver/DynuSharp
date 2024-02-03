using System.Runtime.Serialization;

namespace DynuSharp.Data.Email;
public enum EtrnConnectionSecurityType
{
    [EnumMember(Value = "None")]
    None,
    [EnumMember(Value = "SSLTLS")]
    SSLTLS,
    [EnumMember(Value = "STARTTLSOptional")]
    STARTTLSOptional,
    [EnumMember(Value = "STARTTLSRequired")]
    STARTTLSRequired
}
