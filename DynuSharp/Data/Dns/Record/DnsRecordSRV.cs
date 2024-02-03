using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS SRV (Service Locator) record, which is used to define the location of servers for specified services.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/SRV-Record" target="_blank">
/// SRV Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordSRV : DnsRecordBase
{
    /// <summary>
    /// Specifies the type of the DNS record. For this class, it is always RecordType.SRV.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.SRV;

    /// <summary>
    /// The domain name of the target host that will be providing this service.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "sip.mydomain.com"
    /// </remarks>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// The priority of the target host. Lower values mean higher priority.
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    /// <summary>
    /// The weight of the target host. Used to determine the proportionate weight of this server relative to other SRV records with the same priority.
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    /// The TCP or UDP port on which the service is to be found.
    /// </summary>
    [JsonPropertyName("port")]
    public int Port { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordSRV other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal) &&
               Priority == other.Priority &&
               Weight == other.Weight &&
               Port == other.Port;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host, Priority, Weight, Port);
}