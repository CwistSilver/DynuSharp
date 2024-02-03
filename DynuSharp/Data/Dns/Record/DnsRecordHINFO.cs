using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with HINFO (Host Information) type, which is used to store general information about a host's hardware and operating system.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/HINFO-Record" target="_blank">
/// HINFO Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordHINFO : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to HINFO for this class, signifying that it represents a host information record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.HINFO;

    /// <summary>
    /// The CPU field describes the type of CPU used by the host.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "Xeon"
    /// </remarks>
    [JsonPropertyName("CPU")]
    public string CPU { get; set; } = string.Empty;

    /// <summary>
    /// The Operating System field describes the operating system used by the host.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "Linux"
    /// </remarks>
    [JsonPropertyName("OperatingSystem")]
    public string OperatingSystem { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordHINFO other)
            return false;

        return CPU.Equals(other.CPU, StringComparison.Ordinal) &&
               OperatingSystem.Equals(other.OperatingSystem, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), CPU, OperatingSystem);
}