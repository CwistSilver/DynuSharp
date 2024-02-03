using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns;
public class DnsIpUpdate
{
    /// <summary>
    /// The unique identifier for the IP update.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; init; }

    /// <summary>
    /// The identifier for the server's response to the update request.
    /// </summary>
    [JsonPropertyName("responseId")]
    public string ResponseId { get; init; } = string.Empty;

    /// <summary>
    /// The status of the update operation, represented as an <see cref="UpdateStatus"/> enumeration.
    /// </summary>
    [JsonPropertyName("updateStatus")]
    public UpdateStatus UpdateStatus { get; set; }

    /// <summary>
    /// The IPv4 address involved in the update.
    /// </summary>
    [JsonPropertyName("ipv4Address")]
    public string? IPv4Address { get; init; } = string.Empty;

    /// <summary>
    /// The IPv6 address involved in the update.
    /// </summary>
    [JsonPropertyName("ipv6Address")]
    public string? IPv6Address { get; init; } = string.Empty;

    /// <summary>
    /// The query string used in the update request.
    /// </summary>
    [JsonPropertyName("queryString")]
    public string QueryString { get; init; } = string.Empty;

    /// <summary>
    /// The User-Agent string from the client making the update request.
    /// </summary>
    [JsonPropertyName("userAgent")]
    public string UserAgent { get; init; } = string.Empty;

    /// <summary>
    /// Indicates whether the update was performed over SSL.
    /// </summary>
    [JsonPropertyName("ssl")]
    public bool SSL { get; init; }

    /// <summary>
    /// The date and time when the update was performed.
    /// </summary>
    [JsonPropertyName("updatedOn")]
    public DateTime UpdatedOn { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsIpUpdate other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               ResponseId.Equals(other.ResponseId, StringComparison.Ordinal) &&
               UpdateStatus == other.UpdateStatus &&
               string.Equals(IPv4Address, other.IPv4Address, StringComparison.Ordinal) &&
               string.Equals(IPv6Address, other.IPv6Address, StringComparison.Ordinal) &&
               QueryString.Equals(other.QueryString, StringComparison.Ordinal) &&
               UserAgent.Equals(other.UserAgent, StringComparison.Ordinal) &&
               SSL == other.SSL &&
               UpdatedOn == other.UpdatedOn;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(ResponseId);
        hashCode.Add(UpdateStatus);
        hashCode.Add(IPv4Address);
        hashCode.Add(IPv6Address);
        hashCode.Add(QueryString);
        hashCode.Add(UserAgent);
        hashCode.Add(SSL);
        hashCode.Add(UpdatedOn);
        return hashCode.ToHashCode();
    }
}