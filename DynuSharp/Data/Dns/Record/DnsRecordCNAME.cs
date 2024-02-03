using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with CNAME type which is used to specify a canonical name for an alias of a domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/CNAME-Record" target="_blank">
/// CNAME Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordCNAME : DnsRecordBase
{
    /// <summary>
    /// The type of the DNS record, which is set to CNAME for this class, indicating that this record contains the canonical name for an alias of a domain.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.CNAME;

    /// <summary>
    /// The host represents the target domain to which the alias domain name points. 
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "www.anotherdomain.com"
    /// </remarks>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordCNAME other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host);
}