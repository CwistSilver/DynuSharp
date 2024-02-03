using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with MX (Mail Exchange) type, which is used to specify mail servers responsible for accepting email messages on behalf of a domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/MX-Record" target="_blank">
/// MX Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordMX : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to MX for this class, signifying that it represents a mail exchange record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.MX;

    /// <summary>
    /// The host name of the mail server. 
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "mail.anotherdomain.com"
    /// </remarks>
    [JsonPropertyName("host")]
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// The priority of the mail server. Lower values indicate higher priority. 
    /// It determines the order in which mail servers are used when sending email to the domain.
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordMX other)
            return false;

        return Host.Equals(other.Host, StringComparison.Ordinal) &&
               Priority == other.Priority;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Host, Priority);
}