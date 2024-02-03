using System.Text.Json.Serialization;

namespace DynuSharp.Data.Monitor;
public sealed class MonitorPort : MonitorBase
{
    /// <summary>
    /// The type of the monitor, which is set to PORT for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public override MonitorType Type => MonitorType.PORT;

    /// <summary>
    /// The host that the port monitor should check.
    /// </summary>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// The port number that the port monitor should check.
    /// </summary>
    [JsonPropertyName("port")]
    public int Port { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not MonitorPort other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal) &&
               Port == other.Port;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host, Port);
}