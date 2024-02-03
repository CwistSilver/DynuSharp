using System.Text.Json.Serialization;

namespace DynuSharp.Data.Limit;
/// <summary>
/// Represents a DNS record limit data which inherits from the LimitBase class and adds a list of record types to further define the limit restrictions.
/// </summary>
public sealed class DnsRecordLimitData : LimitBase
{
    /// <summary>
    /// List of applicable DNS record types.
    /// </summary>
    [JsonPropertyName("recordTypes")]
    public IReadOnlyList<string> RecordTypes { get; set; } = new List<string>();
}

