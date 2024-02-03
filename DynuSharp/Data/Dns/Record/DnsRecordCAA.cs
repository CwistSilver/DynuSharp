using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS record with CAA type which is used to specify which Certificate Authorities (CAs) are allowed to issue certificates for a domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/CAA-Record" target="_blank">
/// CAA Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordCAA : DnsRecordBase
{
    /// <summary>
    /// The type of the DNS record, which is set to CAA for this class, used to specify certificate authorities for a domain.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.CAA;

    /// <summary>
    /// Flags to control the behavior of the CAA record. The value ranges from 0 to 255.
    /// <para>Currently only 0 and 128 are used where 0 is for non-critical and 128 is for critical.</para>
    /// </summary>
    [JsonPropertyName("flags")]
    public byte Flags { get; set; }

    /// <summary>
    /// The tag field of the CAA record which represents the property being specified, such as "issue", "issuewild", or "iodef".
    /// </summary>
    [JsonPropertyName("tag")]
    public CAATag Tag { get; set; }

    /// <summary>
    /// The value associated with the tag, often specifying a particular certificate authority for "issue" and "issuewild" tags or a URL for "iodef" tag.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "dynuca.org"
    /// </remarks>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordCAA other)
            return false;

        return Flags == other.Flags &&
               Tag == other.Tag &&
               Value.Equals(other.Value, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Flags, Tag, Value);
}