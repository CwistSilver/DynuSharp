using System.Runtime.Serialization;

namespace DynuSharp.Data.Domain;
public enum TransferState
{
    [EnumMember(Value = "Unknown")]
    Unknown,

    [EnumMember(Value = "TRANSFERPENDINGAUTHCODE")]
    TransferPendingAuthcode,

    [EnumMember(Value = "TRANSFERPENDINGOPS_WHOIS")]
    TransferPendingOpsWhois,

    [EnumMember(Value = "TRANSFERPENDINGAPPROVAL")]
    TransferPendingApproval,

    [EnumMember(Value = "TRANSFERPENDING")]
    TransferPending,

    [EnumMember(Value = "TRANSFERCOMPLETE")]
    TransferComplete,

    [EnumMember(Value = "TRANSFERFAILED")]
    TransferFailed,

    [EnumMember(Value = "TRANSFERCANCELLED")]
    TransferCancelled
}
