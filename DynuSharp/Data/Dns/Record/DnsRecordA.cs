using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with A type which is used to map a domain to an IPv4 address.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/A-Record" target="_blank">
/// A Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordA : DnsRecordBase
{
    /// <summary>
    /// The type of the DNS record, which is set to A for this class.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.A;

    /// <summary>
    /// The group associated with the DNS A record. 
    /// <para>This property can be used to categorize or group DNS records as per your organizational needs.</para>
    /// </summary>
    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// The IPv4 address associated with the DNS A record.
    /// </summary>
    [JsonPropertyName("ipv4Address")]
    public string IPv4Address { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordA other)
            return false;

        return Group.Equals(other.Group, StringComparison.Ordinal) &&
               IPv4Address.Equals(other.IPv4Address, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), IPv4Address, Group);
}