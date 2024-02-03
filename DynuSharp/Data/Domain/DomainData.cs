using DynuSharp.Utilities.Json;
using DynuSharp.Data.Dns;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Domain;
/// <summary>
/// Represents domain-related data for Dynu domains that can be queried using the API.
/// <para>
/// For checking the availability of a desired domain, please visit 
/// <a href="https://www.dynu.com/en-US/ControlPanel/AddDomainRegistration" target="_blank">
/// Dynu Domain Registration
/// </a>.
/// </para>
/// </summary>
public sealed class DomainData
{
    /// <summary>
    /// The unique identifier for the domain. 
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; set; }

    /// <summary>
    /// The name of the domain.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Unicode representation of the domain name.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("unicodeName")]
    [IgnoreOnPost]
    public string UnicodeName { get; set; } = string.Empty;

    /// <summary>
    /// The token associated with the domain.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("token")]
    [IgnoreOnPost]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// The current state of the domain.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("state")]
    [IgnoreOnPost]
    public DomainState State { get; set; }

    /// <summary>
    /// Indicates whether the domain has auto-renewal enabled.
    /// <para>
    /// For more information, see 
    /// <a href="https://www.dynu.com/en-US/Blog/Article?Article=What-happens-after-a-domain-name-expires" target="_blank">
    /// What happens after a domain name expires
    /// </a>.
    /// </para>
    /// </summary>
    [JsonPropertyName("autoRenew")]
    public bool AutoRenewal { get; set; }


    /// <summary>
    /// Indicates whether Whois protection is enabled for the domain.
    /// <para>
    /// For more information, see 
    /// <a href="https://www.dynu.com/en-US/Blog/Article?Article=Domain-Whois-Privacy-Protect-Your-Personal-Information-from-Advertisers" target="_blank">
    /// Domain Whois privacy
    /// </a>.
    /// </para>
    /// </summary>
    [JsonPropertyName("whoisProtected")]
    public bool WhoisProtected { get; set; }


    /// <summary>
    /// The date when the domain expires.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("expiresOn")]
    [IgnoreOnPost]
    public DateTime ExpiresOn { get; set; }

    /// <summary>
    /// The current transfer state of the domain.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("transferState")]
    [IgnoreOnPost]
    public TransferState TransferState { get; set; }

    /// <summary>
    /// The transfer authorization code for the domain.
    /// </summary>
    [JsonPropertyName("transferAuthorizationCode")]
    public string TransferAuthorizationCode { get; set; } = string.Empty;

    /// <summary>
    /// The date and time when the domain transfer was initiated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("transferInitiatedOn")]
    [IgnoreOnPost]
    public DateTime TransferInitiatedOn { get; set; }

    /// <summary>
    /// The date and time when the domain transfer was last updated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("transferUpdatedOn")]
    [IgnoreOnPost]
    public DateTime TransferUpdatedOn { get; set; }

    /// <summary>
    /// The date and time when the domain was created.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("createdOn")]
    [IgnoreOnPost]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// The date and time when the domain was last updated.
    /// <para>Note: Read-only for API requests (This property is not considered when creating or updating through API requests).</para>
    /// </summary>
    [JsonPropertyName("updatedOn")]
    [IgnoreOnPost]
    public DateTime UpdatedOn { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DomainData other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               Name.Equals(other.Name, StringComparison.Ordinal) &&
               UnicodeName.Equals(other.UnicodeName, StringComparison.Ordinal) &&
               Token.Equals(other.Token, StringComparison.Ordinal) &&
               State == other.State &&
               AutoRenewal == other.AutoRenewal &&
               WhoisProtected == other.WhoisProtected &&
               ExpiresOn == other.ExpiresOn &&
               TransferState == other.TransferState &&
               TransferAuthorizationCode.Equals(other.TransferAuthorizationCode, StringComparison.Ordinal) &&
               TransferInitiatedOn == other.TransferInitiatedOn &&
               TransferUpdatedOn == other.TransferUpdatedOn &&
               CreatedOn == other.CreatedOn &&
               UpdatedOn == other.UpdatedOn;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(Name);
        hashCode.Add(UnicodeName);
        hashCode.Add(Token);
        hashCode.Add(State);
        hashCode.Add(AutoRenewal);
        hashCode.Add(WhoisProtected);
        hashCode.Add(ExpiresOn);
        hashCode.Add(TransferState);
        hashCode.Add(TransferAuthorizationCode);
        hashCode.Add(TransferInitiatedOn);
        hashCode.Add(TransferUpdatedOn);
        hashCode.Add(CreatedOn);
        hashCode.Add(UpdatedOn);
        return hashCode.ToHashCode();
    }
}
