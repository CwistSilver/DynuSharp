using System.Text.Json.Serialization;

namespace DynuSharp.Data.DnsWebRedirect;

/// <summary>
/// Represents a DNS web redirect for Port Forwarding (PF). This is used when you want to forward incoming traffic for a specific port 
/// on your domain to another IP address and port. Inherits from <see cref="DnsWebRedirectBase"/> which contains common properties for all redirects.
/// </summary>
public sealed class DnsWebRedirectPF : DnsWebRedirectBase
{
    /// <summary>
    /// The override for the redirect type, set to port forwarding (PF).
    /// </summary>
    public override RedirectType RedirectType => RedirectType.PF;

    /// <summary>
    /// The host to which the web redirect points.
    /// </summary>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// The port to which the web redirect points.
    /// </summary>
    [JsonPropertyName("port")]
    public int Port { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsWebRedirectPF other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal) &&
               Port == other.Port;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host, Port);
}
