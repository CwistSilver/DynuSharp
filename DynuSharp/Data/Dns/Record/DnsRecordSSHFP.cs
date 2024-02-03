using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS SSHFP (SSH Key Fingerprint) record, which is used to store fingerprints of SSH public keys.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/SSHFP-Record" target="_blank">
/// SSHFP Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordSSHFP : DnsRecordBase
{
    /// <summary>
    /// Specifies the type of the DNS record. For this class, it is always RecordType.SSHFP.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.SSHFP;

    /// <summary>
    /// Specifies the algorithm used to generate the SSH public key. The value must be between 0 and 4.<br/>
    /// 0 – Reserved<br/>
    /// 1 – RSA<br/>
    /// 2 – DSA<br/>
    /// 3 – ECDSA<br/>
    /// 4 – ED25519<br/>    
    /// </summary>
    [JsonPropertyName("algorithm")]
    public byte Algorithm { get; set; }

    /// <summary>
    /// Specifies the type of fingerprint, denoting the hash algorithm used to create it. The value should be between 0 and 2.<br/>
    /// 0 – the reserved value<br/>
    /// 1 – SHA-1<br/>
    /// 2 – SHA-256<br/>
    /// </summary>
    [JsonPropertyName("fingerPrintType")]
    public byte FingerPrintType { get; set; }

    /// <summary>
    /// The SSH key fingerprint, generally a hash of the server's public key.
    /// </summary>
    [JsonPropertyName("fingerPrint")]
    public string FingerPrint { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordSSHFP other)
            return false;

        return Algorithm == other.Algorithm &&
               FingerPrintType == other.FingerPrintType &&
               FingerPrint.Equals(other.FingerPrint, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Algorithm, FingerPrintType, FingerPrint);
}