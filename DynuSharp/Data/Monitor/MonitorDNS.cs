using DynuSharp.Data.Email.Type;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Monitor;
public sealed class MonitorDNS : MonitorBase
{
    /// <summary>
    /// The type of the monitor, which is set to DNS for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public override MonitorType Type => MonitorType.DNS;

    /// <summary>
    /// The protocol used for DNS monitoring, either TCP or UDP.
    /// </summary>
    [JsonPropertyName("protocol")]
    public DNSProtocol Protocol { get; set; }

    /// <summary>
    /// The name server to be monitored.
    /// </summary>
    [JsonPropertyName("nameServer")]
    public string NameServer { get; set; } = string.Empty;

    /// <summary>
    /// The hostname to be monitored.
    /// </summary>
    [JsonPropertyName("hostname")]
    public string Hostname { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not MonitorDNS other)
            return false;

        return Protocol == other.Protocol &&
               NameServer.Equals(other.NameServer, StringComparison.Ordinal) &&
               Hostname.Equals(other.Hostname, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Protocol, NameServer, Hostname);
}