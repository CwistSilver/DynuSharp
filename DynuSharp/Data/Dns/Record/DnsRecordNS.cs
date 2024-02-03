using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with NS (Name Server) type, which is used to specify the authoritative DNS servers for the domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/NS-Record" target="_blank">
/// NS Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordNS : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to NS for this class, signifying that it represents a name server record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.NS;

    /// <summary>
    /// The hostname for the authoritative name server for the domain.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "ns2.anotherdomain.com"
    /// </remarks>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordNS other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host);
}