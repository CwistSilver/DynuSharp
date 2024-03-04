using DynuSharp.Utilities.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email;
public sealed class QueuedEmailMessage
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;

    [JsonPropertyName("from")]
    public string From { get; set; } = string.Empty;

    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;

    [JsonPropertyName("tries")]
    [IgnoreOnPost]
    public int Tries { get; set; }

    [JsonPropertyName("createdOn")]
    [IgnoreOnPost]
    public DateTime CreatedOn { get; set; }

    [JsonPropertyName("nextRetryOn")]
    [IgnoreOnPost]
    public DateTime NextRetryOn { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not QueuedEmailMessage other)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Uid.Equals(other.Uid, StringComparison.Ordinal) &&
               From.Equals(other.From, StringComparison.Ordinal) &&
               To.Equals(other.To, StringComparison.Ordinal) &&
               Tries == other.Tries &&
               CreatedOn == other.CreatedOn &&
               NextRetryOn == other.NextRetryOn;
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Uid);
        hashCode.Add(From);
        hashCode.Add(To);
        hashCode.Add(Tries);
        hashCode.Add(CreatedOn);
        hashCode.Add(NextRetryOn);
        return hashCode.ToHashCode();
    }
}
