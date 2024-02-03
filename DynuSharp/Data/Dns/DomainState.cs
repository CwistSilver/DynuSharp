using System.Runtime.Serialization;

namespace DynuSharp.Data.Dns;
public enum DomainState
{
    [EnumMember(Value = "Unknown")]
    Unknown,

    [EnumMember(Value = "AwaitingPayment")]
    AwaitingPayment,

    [EnumMember(Value = "AwaitingAuthorizationCode")]
    AwaitingAuthorizationCode,

    [EnumMember(Value = "AwaitingIPSTAGChange")]
    AwaitingIPSTAGChange,

    [EnumMember(Value = "Complete")]
    Complete,

    [EnumMember(Value = "Cancelled")]
    Cancelled,

    [EnumMember(Value = "Expired")]
    Expired,

    [EnumMember(Value = "TransferPending")]
    TransferPending,

    [EnumMember(Value = "TransferFailed")]
    TransferFailed,

    [EnumMember(Value = "RedemptionPeriod")]
    RedemptionPeriod,

    [EnumMember(Value = "Provisioning")]
    Provisioning
}