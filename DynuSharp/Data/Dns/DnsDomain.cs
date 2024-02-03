using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns;
/// <summary>
/// Represents a DNS Domain, enabling the mapping of readable names to IP addresses in network navigation.
/// </summary>
public sealed class DnsDomain
{
    /// <summary>
    /// The unique identifier for the domain. 
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The name of the domain. The domain name must belong to the set of top-level domains specified in the <see cref="TopLevelDomains"/> class.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Unicode representation of the domain name.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("unicodeName")]
    [IgnoreOnPost]
    public string UnicodeName { get; set; } = string.Empty;

    /// <summary>
    /// The token associated with the domain.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("token")]
    [IgnoreOnPost]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// The current state of the domain.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("state")]
    [IgnoreOnPost]
    public DomainState State { get; set; }

    /// <summary>
    /// The group that the domain is associated with.
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group { get; set; }

    /// <summary>
    /// The IPv4 address associated with the domain.
    /// </summary>
    [JsonPropertyName("ipv4Address")]
    public string? IPv4Address { get; set; }

    /// <summary>
    /// The IPv6 address associated with the domain. It can be null.
    /// </summary>
    [JsonPropertyName("ipv6Address")]
    public string? IPv6Address { get; set; }

    /// <summary>
    /// The Time-To-Live (TTL) value for the domain, in seconds.
    /// </summary>
    [JsonPropertyName("ttl")]
    public int TTL { get; set; }

    /// <summary>
    /// Indicates whether the IPv4 protocol is enabled for the domain.
    /// </summary>
    [JsonPropertyName("ipv4")]
    public bool IPv4 { get; set; }

    /// <summary>
    /// Indicates whether the IPv6 protocol is enabled for the domain.
    /// </summary>
    [JsonPropertyName("ipv6")]
    public bool IPv6 { get; set; }

    /// <summary>
    /// Indicates whether the IPv4 wildcard alias is enabled for the domain.
    /// </summary>
    [JsonPropertyName("ipv4WildcardAlias")]
    public bool IPv4WildcardAlias { get; set; }

    /// <summary>
    /// Indicates whether the IPv6 wildcard alias is enabled for the domain.
    /// </summary>
    [JsonPropertyName("ipv6WildcardAlias")]
    public bool IPv6WildcardAlias { get; set; }

    /// <summary>
    /// Indicates whether zone transfers are allowed for the domain.
    /// </summary>
    [JsonPropertyName("allowZoneTransfer")]
    public bool AllowZoneTransfer { get; set; }

    /// <summary>
    /// Indicates whether DNSSEC (Domain Name System Security Extensions) is enabled for the domain.
    /// </summary>
    [JsonPropertyName("dnssec")]
    public bool DNSSEC { get; set; }

    /// <summary>
    /// The date and time when the domain was created.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("createdOn")]
    [IgnoreOnPost]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time when the domain was last updated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("updatedOn")]
    [IgnoreOnPost]
    public DateTime UpdatedOn { get; set; }

    public override string ToString() => $"{Name} ({Id})";

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsDomain other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
              Name.Equals(other.Name, StringComparison.Ordinal) &&
              UnicodeName.Equals(other.UnicodeName, StringComparison.Ordinal) &&
              Token.Equals(other.Token, StringComparison.Ordinal) &&
              State == other.State &&
              string.Equals(Group, other.Group, StringComparison.Ordinal) &&
              string.Equals(IPv4Address, other.IPv4Address, StringComparison.Ordinal) &&
              string.Equals(IPv6Address, other.IPv6Address, StringComparison.Ordinal) &&
              TTL == other.TTL &&
              IPv4 == other.IPv4 &&
              IPv6 == other.IPv6 &&
              IPv4WildcardAlias == other.IPv4WildcardAlias &&
              IPv6WildcardAlias == other.IPv6WildcardAlias &&
              AllowZoneTransfer == other.AllowZoneTransfer &&
              DNSSEC == other.DNSSEC &&
              CreatedOn == other.CreatedOn &&
              UpdatedOn == other.UpdatedOn;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(Name);
        hashCode.Add(UnicodeName);
        hashCode.Add(Token);
        hashCode.Add(State);
        hashCode.Add(Group);
        hashCode.Add(IPv4Address);
        hashCode.Add(IPv6Address);
        hashCode.Add(TTL);
        hashCode.Add(IPv4);
        hashCode.Add(IPv6);
        hashCode.Add(IPv4WildcardAlias);
        hashCode.Add(IPv6WildcardAlias);
        hashCode.Add(AllowZoneTransfer);
        hashCode.Add(DNSSEC);
        hashCode.Add(CreatedOn);
        hashCode.Add(UpdatedOn);
        return hashCode.ToHashCode();
    }
}