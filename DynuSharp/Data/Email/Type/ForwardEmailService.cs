using DynuSharp.Data.Email;
using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email.Type;
public sealed class ForwardEmailService : DynuEmailServiceBase
{
    [JsonPropertyName("type")]
    public override EmailType Type => EmailType.EmailForward;

    [JsonPropertyName("catchAllAddress")]
    public string CatchAllAddress { get; set; } = string.Empty;

    [JsonPropertyName("plusAddressing")]
    public bool PlusAddressing { get; set; }

    [JsonPropertyName("plusAddressingCharacter")]
    public string PlusAddressingCharacter { get; set; } = string.Empty;

    [JsonPropertyName("greyListing")]
    public bool GreyListing { get; set; }

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj) || obj is not ForwardEmailService other)
            return false;

        return CatchAllAddress.Equals(other.CatchAllAddress, StringComparison.Ordinal) &&
               PlusAddressing == other.PlusAddressing &&
               PlusAddressingCharacter.Equals(other.PlusAddressingCharacter, StringComparison.Ordinal) &&
               GreyListing == other.GreyListing;
    }

    public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), CatchAllAddress, PlusAddressing, PlusAddressingCharacter, GreyListing);
}
