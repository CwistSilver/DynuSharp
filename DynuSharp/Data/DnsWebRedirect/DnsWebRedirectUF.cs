using System.Text.Json.Serialization;

namespace DynuSharp.Data.DnsWebRedirect;

/// <summary>
/// Represents a DNS web redirect for URL Forwarding (UF). This is used when you want to redirect one URL to another, 
/// preserving the path and query string. Inherits from <see cref="DnsWebRedirectBase"/> which contains common properties for all redirects.
/// </summary>
public sealed class DnsWebRedirectUF : DnsWebRedirectBase
{
    /// <summary>
    /// The override for the redirect type, set to URL forwarding (UF).
    /// </summary>
    public override RedirectType RedirectType => RedirectType.UF;

    /// <summary>
    /// The URL to which the web redirect points.
    /// <para>Note: This property only applies when the redirect type is UF.</para>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsWebRedirectUF other)
            return false;

        return Url.Equals(other.Url, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Url);
}
