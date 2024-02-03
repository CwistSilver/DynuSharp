using DynuSharp.Data.Dns;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Dns.Group;
public sealed class DnsGroupClient : BaseClient, IDnsGroupClient
{
    private const string GettAllPath = "dns/group";
    private const string AddPath = "dns/group";
    private const string UpdatePath = "dns/group/{0}";
    private const string DeletePath = "dns/group/{0}";

    private const string JsonPropertyName = "groups";
    public DnsGroupClient(IConnection connection) : base(connection) { }

    public async Task<IReadOnlyList<DnsGroup>> GetListAsync() => await Get<IReadOnlyList<DnsGroup>>(GettAllPath, JsonPropertyName);

    public async Task<DnsGroup> AddAsync(DnsGroup dnsGroup)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsGroup, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DnsGroup>(AddPath, content);
    }

    public async Task<DnsGroup> UpdateAsync(int id, DnsGroup dnsGroup)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsGroup, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DnsGroup>(string.Format(UpdatePath, id), content);
    }

    public async Task DeleteAsync(int id) => await Delete(string.Format(DeletePath, id));
}
