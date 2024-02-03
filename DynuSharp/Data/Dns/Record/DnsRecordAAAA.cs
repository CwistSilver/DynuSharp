using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with AAAA type which is used to map a domain to an IPv6 address.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/AAAA-Record" target="_blank">
/// AAAA Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordAAAA : DnsRecordBase
{
    /// <summary>
    /// The type of the DNS record, which is set to AAAA for this class, used for IPv6 address records.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.AAAA;

    /// <summary>
    /// The group associated with the DNS AAAA record. 
    /// <para>This property can be used to categorize or group DNS records as per your organizational needs.</para>
    /// </summary>
    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// The IPv6 address associated with the DNS AAAA record.
    /// </summary>
    [JsonPropertyName("ipv6Address")]
    public string IPv6Address { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordAAAA other)
            return false;

        return Group.Equals(other.Group, StringComparison.Ordinal) &&
               IPv6Address.Equals(other.IPv6Address, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), IPv6Address, Group);
}