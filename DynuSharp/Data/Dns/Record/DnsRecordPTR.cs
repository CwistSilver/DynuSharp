using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with PTR (Pointer) type, which is used primarily for reverse DNS lookups.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/PTR-Record" target="_blank">
/// PTR Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordPTR : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to PTR for this class, signifying that it represents a pointer record used in reverse DNS lookups.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.PTR;

    /// <summary>
    /// The host for which this PTR record is specifying a reverse DNS entry.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "10.207.160.216.in-addr.arpa"
    /// </remarks>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordPTR other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host);
}