using System.Runtime.Serialization;

namespace DynuSharp.Data.Email;
public enum EmailState
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "AwaitingPayment")]
    AwaitingPayment,
    [EnumMember(Value = "Complete")]
    Complete,
    [EnumMember(Value = "OnHold")]
    OnHold,
    [EnumMember(Value = "Cancelled")]
    Cancelled,
    [EnumMember(Value = "Expired")]
    Expired,
    [EnumMember(Value = "Provisioning")]
    Provisioning,
    [EnumMember(Value = "Other")]
    Other
}