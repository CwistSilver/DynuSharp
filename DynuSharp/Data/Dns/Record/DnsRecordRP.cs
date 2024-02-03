using System.Text.Json.Serialization;

namespace DynuSharp.Data.Dns.Record;
/// <summary>
/// Represents a DNS RP (Responsible Person) record that associates a domain name with the responsible person's mailbox and an optional TXT record describing the person.
/// <para>
/// Learn more about
/// <a href="https://www.dynu.com/Resources/DNS-Records/RP-Record" target="_blank">
/// RP Records
/// </a>
/// </para>
/// </summary>
public sealed class DnsRecordRP : DnsRecordBase
{
    /// <summary>
    /// The type of DNS record, which is set to RP for this class, signifying that it represents a Responsible Person record.
    /// </summary>
    [JsonPropertyName("recordType")]
    public override RecordType RecordType => RecordType.RP;

    /// <summary>
    /// The email address of the responsible person for the domain.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "admin.domain.com"
    /// </remarks>
    [JsonPropertyName("mailBox")]
    public string MailBox { get; set; } = string.Empty;

    /// <summary>
    /// The domain name where a TXT record can be found with more information about the responsible person. It can be blank, indicating there is no associated TXT record.
    /// </summary>
    /// <remarks>
    /// Example value: 
    /// "domain.com"
    /// </remarks>
    [JsonPropertyName("txtDomainName")]
    public string TxtDomainName { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not DnsRecordRP other)
            return false;

        return MailBox.Equals(other.MailBox, StringComparison.Ordinal) &&
               TxtDomainName.Equals(other.TxtDomainName, StringComparison.Ordinal);
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), MailBox, TxtDomainName);
}