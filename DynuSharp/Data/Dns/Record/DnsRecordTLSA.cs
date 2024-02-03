using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS TLSA (Transport Layer Security Authentication) record. 
/// This record is used to associate a TLS server certificate or public key with the domain name where the record is found, 
/// thus forming a basis for name-based certificate validation.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/TLSA-Record" target="_blank">
/// TLSA Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordTLSA : DnsRecordBase
{
    /// <summary>
    /// Specifies the type of the DNS record. For this class, it is always RecordType.TLSA.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.TLSA;

    /// <summary>
    /// Specifies the certificate usage, dictating how the TLS certificate provided by the server should be matched against the certificate association data.
    /// Allowed values: 0-3.
    /// </summary>
    [JsonPropertyName("certificateUsage")]
    public byte CertificateUsage { get; set; }

    /// <summary>
    /// Specifies the selector determining which part of the TLS certificate will be matched against the association data.
    /// Allowed values: 0-1.
    /// </summary>
    [JsonPropertyName("selector")]
    public byte Selector { get; set; }

    /// <summary>
    /// Specifies the matching type, defining how the certificate association is presented.
    /// Allowed values: 0-2.
    /// </summary>
    [JsonPropertyName("matchingType")]
    public byte MatchingType { get; set; }

    /// <summary>
    /// Specifies the certificate association data used for matching the certificate presented in the TLS handshake.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "0D6FCE3320315023FF499A3F3DE1C362C88F8380311AC8C036890DAB13243AA7"
    /// </remarks>
    [JsonPropertyName("certificateAssociatedData")]
    public string CertificateAssociatedData { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordTLSA other)
            return false;

        return CertificateUsage == other.CertificateUsage &&
               Selector == other.Selector &&
               MatchingType == other.MatchingType &&
               CertificateAssociatedData.Equals(other.CertificateAssociatedData, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), CertificateUsage, Selector, MatchingType, CertificateAssociatedData);
}