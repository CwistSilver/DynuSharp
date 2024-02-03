using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS SOA (Start of Authority) record which provides information about the domain and the zone, especially regarding DNS administration.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/SOA-Record" target="_blank">
/// SOA Records
/// </a>
/// </para>
/// </summary>
public class DnsRecordSOA : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to SOA for this class, signifying that it represents a Start of Authority record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.SOA;

    /// <summary>
    /// The domain name of the primary DNS server for the zone, which is authoritative for the domain.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "ns1.dynu.com"
    /// </remarks>
    [JsonPropertyName("masterName")]
    public string MasterName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the responsible person for the domain, but in domain format, e.g., "hostmaster.example.com" for "hostmaster@example.com".
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "administrator.dynu.com"
    /// </remarks>
    [JsonPropertyName("responsibleName")]
    public string ResponsibleName { get; set; } = string.Empty;

    /// <summary>
    /// The time, in seconds, after which secondary DNS servers should check if updates are needed.
    /// </summary>
    [JsonPropertyName("refresh")]
    public int Refresh { get; set; }

    /// <summary>
    /// The time, in seconds, that secondary servers should wait before retrying a failed zone transfer. Typically, this value is less than the refresh interval.
    /// </summary>
    [JsonPropertyName("retry")]
    public int Retry { get; set; }

    /// <summary>
    /// The time, in seconds, after which secondary DNS servers should discard cached information if no refresh has been successful.
    /// </summary>
    [JsonPropertyName("expire")]
    public int Expire { get; set; }

    /// <summary>
    /// The time, in seconds, that DNS servers should cache negative responses (i.e., records not found).
    /// </summary>
    [JsonPropertyName("negativeTTL")]
    public int NegativeTTL { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        if (obj is not DnsRecordSOA other)
            return false;

        return MasterName.Equals(other.MasterName, StringComparison.Ordinal) &&
               ResponsibleName.Equals(other.ResponsibleName, StringComparison.Ordinal) &&
               Refresh == other.Refresh &&
               Retry == other.Retry &&
               Expire == other.Expire &&
               NegativeTTL == other.NegativeTTL;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), MasterName, ResponsibleName, Refresh, Retry, Expire, NegativeTTL);
}