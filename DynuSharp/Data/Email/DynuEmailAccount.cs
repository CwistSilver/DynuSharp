using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email;
public sealed class DynuEmailAccount
{
    [JsonPropertyName("id")]
    [IgnoreOnPost]
    public int Id { get; init; }

    [JsonPropertyName("emailId")]
    public int EmailId { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; } = string.Empty;

    [JsonPropertyName("unicodeEmailAddress")]
    [IgnoreOnPost]
    public string UnicodeEmailAddress { get; init; } = string.Empty;

    [JsonPropertyName("state")]
    public EmailAccountState State { get; set; }

    [JsonPropertyName("useForwarding")]
    public bool UseForwarding { get; set; }

    [JsonPropertyName("keepOriginalMessage")]
    public bool KeepOriginalMessage { get; set; }

    [JsonPropertyName("forwardAddress")]
    public string ForwardAddress { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not DynuEmailAccount other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Id == other.Id &&
               EmailId == other.EmailId &&
               EmailAddress.Equals(other.EmailAddress, StringComparison.Ordinal) &&
               UnicodeEmailAddress.Equals(other.UnicodeEmailAddress, StringComparison.Ordinal) &&
               State == other.State &&
               UseForwarding == other.UseForwarding &&
               KeepOriginalMessage == other.KeepOriginalMessage &&
               ForwardAddress.Equals(other.ForwardAddress, StringComparison.Ordinal) &&
               Password.Equals(other.Password, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Id);
        hashCode.Add(EmailId);
        hashCode.Add(EmailAddress);
        hashCode.Add(UnicodeEmailAddress);
        hashCode.Add(State);
        hashCode.Add(UseForwarding);
        hashCode.Add(KeepOriginalMessage);
        hashCode.Add(ForwardAddress);
        hashCode.Add(Password);
        return hashCode.ToHashCode();
    }
}
