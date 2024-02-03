using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Ping;
public sealed class PingClient : BaseClient, IPingClient
{
    private const string PingPath = "ping";
    private const string QueryPingPath = "ping/?message={0}";

    public PingClient(IConnection connection) : base(connection) { }

    public async Task<string> PingWithBodyAsync(string message)
    {
        var content = new StringContent(JsonSerializer.Serialize(new { message }), Encoding.UTF8, "application/json");
        var responseData = await Post<string>(PingPath, content);
        JsonDocument doc = JsonDocument.Parse(responseData);

        return doc.RootElement.GetProperty("message").GetString()!;
    }

    public async Task<string> PingWithQueryAsync(string message)
    {
        var responseData = await Get<string>(string.Format(QueryPingPath, Uri.EscapeDataString(message)));
        JsonDocument doc = JsonDocument.Parse(responseData);

        return doc.RootElement.GetProperty("message").GetString()!;
    }
}
