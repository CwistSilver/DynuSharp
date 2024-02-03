using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns;
public sealed class RootDnsDomain
{
    /// <summary>
    /// The unique identifier for the domain. 
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The hostname associated with the domain. This refers to the specific machine or service within the domain.
    /// </summary>
    [JsonPropertyName("hostname")]
    public string Hostname { get; set; } = string.Empty;

    /// <summary>
    /// The name of the domain. This represents the larger network or system to which the hostname belongs.
    /// </summary>
    [JsonPropertyName("domainName")]
    public string DomainName { get; set; } = string.Empty;

    /// <summary>
    /// The node associated with the domain data, representing a specific location or area within the larger network defined by the domain name.
    /// </summary>
    [JsonPropertyName("node")]
    public string Node { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not RootDnsDomain other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               Hostname.Equals(other.Hostname, StringComparison.Ordinal) &&
               DomainName.Equals(other.DomainName, StringComparison.Ordinal) &&
               Node.Equals(other.Node, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(Id, Hostname, DomainName, Node);
}
