using System.Text.Json.Serialization;

namespace DynuSharp.Data.Monitor;
public sealed class MonitorPing : MonitorBase
{
    /// <summary>
    /// The type of the monitor, which is set to PING for this class.
    /// </summary>
    [JsonPropertyName("type")]
    public override MonitorType Type => MonitorType.PING;

    /// <summary>
    /// The host that the ping monitor should check.
    /// </summary>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not MonitorPing other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host);
}