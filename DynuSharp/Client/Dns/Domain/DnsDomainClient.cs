using DynuSharp.Data.Dns;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Dns.Domain;
public sealed class DnsDomainClient : BaseClient, IDnsDomainClient
{
    private const string GetAllPath = "dns";
    private const string GetPath = "dns/{0}";
    private const string GetRootPath = "dns/getroot/{0}";
    private const string AddPath = "dns";
    private const string UpdatePath = "dns/{0}";
    private const string DeletePath = "dns/{0}";

    private const string JsonPropertyName = "domains";

    public DnsDomainClient(IConnection connection) : base(connection) { }

    public async Task<IReadOnlyList<DnsDomain>> GetListAsync() => await Get<List<DnsDomain>>(GetAllPath, JsonPropertyName);
    public async Task<RootDnsDomain> GetRootAsync(string hostname) => await Get<RootDnsDomain>(string.Format(GetRootPath, hostname));
    public async Task<DnsDomain> GetAsync(int id) => await Get<DnsDomain>(string.Format(GetPath, id));

    public async Task AddAsync(DnsDomain dnsDomain)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsDomain, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        await Post(AddPath, content);
    }

    public async Task UpdateAsync(int id, DnsDomain dnsDomain)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsDomain, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        await Post(string.Format(UpdatePath, id), content);
    }

    public async Task DeleteAsync(int id) => await Delete(string.Format(DeletePath, id));
}
