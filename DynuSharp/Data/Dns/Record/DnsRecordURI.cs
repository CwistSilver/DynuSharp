using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS URI record, used to specify the location of services using a given URI.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/URI-Record" target="_blank">
/// URI Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordURI : DnsRecordBase
{
    /// <summary>
    /// Specifies the type of the DNS record. For this class, it is always RecordType.URI.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.URI;

    /// <summary>
    /// Priority of the target in this record. Lower values are preferred.
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    /// <summary>
    /// Weight for load balancing when multiple targets have the same priority. Higher values are preferred.
    /// </summary>
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    /// <summary>
    /// The URI where the service is located. This could be a URL to a server, an email address, or any other type of URI.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "ftp://ftp.example.com/public"
    /// </remarks>
    [JsonPropertyName("targetUri")]
    public string TargetUri { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordURI other)
            return false;

        return Priority == other.Priority &&
               Weight == other.Weight &&
               TargetUri.Equals(other.TargetUri, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Priority, Weight, TargetUri);
}