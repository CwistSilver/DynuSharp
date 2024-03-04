using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;

/// <summary>
/// Represents the base class for DNS records.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records" target="_blank">
/// DNS Records
/// </a>
/// </para>
/// </summary>
public class DnsRecordBase
{
    /// <summary>
    /// The unique identifier for the DNS record.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier for the domain associated with the DNS record.
    /// </summary>
    [JsonPropertyName("domainId")]
    public int DomainId { get; set; }

    /// <summary>
    /// The name of the domain associated with the DNS record.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("domainName")]
    [IgnoreOnPost]
    public string DomainName { get; set; } = string.Empty;

    /// <summary>
    /// The name of the node associated with the DNS record.
    /// </summary>
    [JsonPropertyName("nodeName")]
    public string NodeName { get; set; } = string.Empty;

    /// <summary>
    /// The hostname associated with the DNS record.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("hostname")]
    [IgnoreOnPost]
    public string Hostname { get; set; } = string.Empty;

    /// <summary>
    /// The type of the DNS record. This can be one of several enumerated values representing different DNS record types.
    /// </summary>
    [JsonPropertyName("recordType")]
    public virtual RecordType RecordType { get; }

    /// <summary>
    /// The state of the DNS record. Typically used to represent if the record is active or not.
    /// </summary>
    [JsonPropertyName("state")]
    public bool State { get; set; }

    /// <summary>
    /// The content associated with the DNS record.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("content")]
    [IgnoreOnPost]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The date and time when the DNS record was last updated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("updatedOn")]
    [IgnoreOnPost]
    public DateTime UpdatedOn { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DnsRecordBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
           DomainId == other.DomainId &&
           DomainName.Equals(other.DomainName, StringComparison.Ordinal) &&
           NodeName.Equals(other.NodeName, StringComparison.Ordinal) &&
           Hostname.Equals(other.Hostname, StringComparison.Ordinal) &&
           RecordType == other.RecordType &&
           State == other.State &&
           Content.Equals(other.Content, StringComparison.Ordinal) &&
           UpdatedOn == other.UpdatedOn;
    }

    public override int GetHashCode() => HashCode.Combine(Id, DomainId, NodeName, RecordType, State);
}