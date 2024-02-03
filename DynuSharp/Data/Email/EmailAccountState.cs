using System.Runtime.Serialization;

namespace DynuSharp.Data.Email;
public enum EmailAccountState
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "Active")]
    Active,
    [EnumMember(Value = "InActive")]
    InActive
}
