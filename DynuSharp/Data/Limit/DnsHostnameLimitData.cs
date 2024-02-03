using System.Text.Json.Serialization;

namespace DynuSharp.Data.Limit;
/// <summary>
/// Represents a DNS hostname limit data which inherits from the LimitBase class and adds a domain type property to further specify the limit context.
/// </summary>
public sealed class DnsHostnameLimitData : LimitBase
{
    /// <summary>
    /// The classification of the domain which can be a top-level domain or other categorizations.
    /// </summary>
    [JsonPropertyName("domainType")]
    public string DomainType { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsHostnameLimitData other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return DomainType.Equals(other.DomainType, StringComparison.Ordinal);
    }

    public override int GetHashCode() => DomainType.GetHashCode();
}
