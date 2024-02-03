using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS SPF (Sender Policy Framework) record which is used to identify which mail servers are permitted to send email on behalf of your domain.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/Tutorials/DynamicDNS/CreateSPFRecord" target="_blank">
/// SPF Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordSPF : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to SPF for this class, signifying that it represents a Sender Policy Framework record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.SPF;

    /// <summary>
    /// The text data for the SPF record which specifies the rules for which servers can send mail on behalf of the domain. 
    /// </summary>
    /// <para>Example value:</para>
    /// <remarks>
    /// Example value: 
    /// "v=spf1 include:_spf.somedomain.com ~all"
    /// </remarks>
    [JsonPropertyName("textData")]
    public string TextData { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordSPF other)
            return false;

        return TextData.Equals(other.TextData, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), TextData);
}