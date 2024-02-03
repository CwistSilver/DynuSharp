using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS TXT (Text) record, which can hold arbitrary text and can also be used to define machine-readable data, such as security or abuse prevention information.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/TXT-Record" target="_blank">
/// TXT Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordTXT : DnsRecordBase
{
    /// <summary>
    /// Specifies the type of the DNS record. For this class, it is always RecordType.TXT.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.TXT;

    /// <summary>
    /// Specifies the text data held in the TXT record. This can be any arbitrary text and often holds machine-readable data.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "facebook-domain-verification=22rm551cu4k0ab0bxsw536tlds4h95"
    /// </remarks>
    [JsonPropertyName("textData")]
    public string TextData { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordTXT other)
            return false;

        return TextData.Equals(other.TextData, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), TextData);
}