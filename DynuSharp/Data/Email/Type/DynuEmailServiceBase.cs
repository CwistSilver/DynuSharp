using DynuSharp.Data.Dns.Record;
using DynuSharp.Utilities.Json;
using DynuSharp.Data.Email;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email.Type;
public class DynuEmailServiceBase
{
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("unicodeName")]
    [IgnoreOnPost]
    public string UnicodeName { get; set; } = string.Empty;

    [JsonPropertyName("token")]
    [IgnoreOnPost]
    public string Token { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    [IgnoreOnPost]
    public EmailState State { get; set; }

    [JsonPropertyName("type")]
    [IgnoreOnPost]
    public virtual EmailType Type { get; set; }

    [JsonPropertyName("autoRenew")]
    public bool AutoRenewal { get; set; }

    [JsonPropertyName("antiSpam")]
    public bool AntiSpam { get; set; }

    [JsonPropertyName("expiresOn")]
    [IgnoreOnPost]
    public DateTime ExpiresOn { get; set; }

    [JsonPropertyName("createdOn")]
    [IgnoreOnPost]
    public DateTime CreatedOn { get; set; }

    [JsonPropertyName("updatedOn")]
    [IgnoreOnPost]
    public DateTime UpdatedOn { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DynuEmailServiceBase other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               Name.Equals(other.Name, StringComparison.Ordinal) &&
               UnicodeName.Equals(other.UnicodeName, StringComparison.Ordinal) &&
               Token.Equals(other.Token, StringComparison.Ordinal) &&
               State == other.State &&
               Type == other.Type &&
               AutoRenewal == other.AutoRenewal &&
               ExpiresOn == other.ExpiresOn &&
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
        hashCode.Add(Type);
        hashCode.Add(State);
        hashCode.Add(AutoRenewal);
        hashCode.Add(ExpiresOn);
        hashCode.Add(CreatedOn);
        hashCode.Add(UpdatedOn);
        return hashCode.ToHashCode();
    }
}
