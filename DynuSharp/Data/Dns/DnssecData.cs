using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns;
/// <summary>
/// Represents the DNS Security Extensions (DNSSEC) data for a domain, providing details necessary to facilitate DNSSEC authentication and secure DNS responses.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/DNSSEC" target="_blank">
/// DNSSEC
/// </a>
/// </para>
/// </summary>
public sealed class DnssecData
{
    /// <summary>
    /// The unique identifier for the DNSSEC data entry.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The domain name associated with this DNSSEC data entry.
    /// </summary>
    [JsonPropertyName("domainName")]
    public string DomainName { get; set; } = string.Empty;

    /// <summary>
    /// The Delegation Signer (DS) record, which is used to secure delegations in the DNSSEC protocol.
    /// </summary>
    [JsonPropertyName("dsRecord")]
    public string DsRecord { get; set; } = string.Empty;

    /// <summary>
    /// The cryptographic hash of a DNSKEY record, which is a part of the DNSSEC protocol to ensure DNS responses are authentic.
    /// </summary>
    [JsonPropertyName("digest")]
    public string Digest { get; set; } = string.Empty;

    /// <summary>
    /// The type of cryptographic hash used in creating the digest.
    /// </summary>
    [JsonPropertyName("digestType")]
    public DigestType DigestType { get; set; }

    /// <summary>
    /// The algorithm used in the DNSSEC protocol, which defines how the DNS data will be encrypted.
    /// </summary>
    [JsonPropertyName("algorithm")]
    public int Algorithm { get; set; }

    /// <summary>
    /// The public key used as part of the DNSSEC protocol, allowing for the authentication of DNS responses.
    /// </summary>
    [JsonPropertyName("publicKey")]
    public string PublicKey { get; set; } = string.Empty;

    /// <summary>
    /// The key tag is used to help efficiently select one of potentially many DNSKEY records in a DNSSEC response.
    /// </summary>
    [JsonPropertyName("keyTag")]
    public int KeyTag { get; set; }

    /// <summary>
    /// Flags used to define various settings and attributes for DNSSEC, influencing how it operates for the given domain.
    /// </summary>
    [JsonPropertyName("flags")]
    public int Flags { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || !(obj is DnssecData other))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               DomainName.Equals(other.DomainName, StringComparison.Ordinal) &&
               DsRecord.Equals(other.DsRecord, StringComparison.Ordinal) &&
               Digest.Equals(other.Digest, StringComparison.Ordinal) &&
               DigestType == other.DigestType &&
               Algorithm == other.Algorithm &&
               PublicKey.Equals(other.PublicKey, StringComparison.Ordinal) &&
               KeyTag == other.KeyTag &&
               Flags == other.Flags;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(DomainName);
        hashCode.Add(DsRecord);
        hashCode.Add(Digest);
        hashCode.Add(DigestType);
        hashCode.Add(Algorithm);
        hashCode.Add(PublicKey);
        hashCode.Add(KeyTag);
        hashCode.Add(Flags);
        return hashCode.ToHashCode();
    }
}