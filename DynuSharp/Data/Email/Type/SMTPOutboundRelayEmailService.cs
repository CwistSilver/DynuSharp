using System.Text.Json.Serialization;

namespace DynuSharp.Data.Email.Type;
public sealed class SMTPOutboundRelayEmailService : DynuEmailServiceBase
{
    [JsonPropertyName("type")]
    public override EmailType Type => EmailType.SMTPOutboundRelay;
}
