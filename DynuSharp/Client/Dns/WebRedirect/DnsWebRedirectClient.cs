using DynuSharp.Data.DnsWebRedirect;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Dns.WebRedirect;
public class DnsWebRedirectClient : BaseClient, IDnsWebRedirectClient
{
    private const string GetAllPath = "dns/{0}/webRedirect";
    private const string GetPath = "dns/{0}/webRedirect/{1}";
    private const string AddPath = "dns/{0}/webredirect";
    private const string UpdatePath = "dns/{0}/webredirect/{1}";
    private const string DeletePath = "dns/{0}/webredirect/{1}";

    private const string JsonPropertyName = "webRedirects";

    private readonly IDeserializer<DnsWebRedirectBase> _webRedirectDeserializer;
    public DnsWebRedirectClient(IConnection connection, IDeserializer<DnsWebRedirectBase> webRedirectDeserializer) : base(connection)
    {
        _webRedirectDeserializer = webRedirectDeserializer;
    }

    public async Task<IReadOnlyList<DnsWebRedirectBase>> GetListAsync(int id)
        => await GetList(string.Format(GetAllPath, id), _webRedirectDeserializer, JsonPropertyName);

    public async Task<DnsWebRedirectBase> GetAsync(int id, int webRedirectId)
        => await Get(string.Format(GetPath, id, webRedirectId), _webRedirectDeserializer);

    public async Task<T> GetAsync<T>(int id, int webRedirectId) where T : DnsWebRedirectBase
        => await Get<T, DnsWebRedirectBase>(string.Format(GetPath, id, webRedirectId), _webRedirectDeserializer);

    public async Task<DnsWebRedirectBase> AddAsync(int id, DnsWebRedirectBase dnsWebRedirect)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsWebRedirect, dnsWebRedirect.GetType(), GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post(string.Format(AddPath, id), content, _webRedirectDeserializer);
    }

    public async Task<DnsWebRedirectBase> UpdateAsync(int id, int webRedirectId, DnsWebRedirectBase dnsWebRedirect)
    {
        var content = new StringContent(JsonSerializer.Serialize(dnsWebRedirect, dnsWebRedirect.GetType(), GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post(string.Format(UpdatePath, id, webRedirectId), content, _webRedirectDeserializer);
    }

    public async Task DeleteAsync(int id, int webRedirectId) => await Delete(string.Format(DeletePath, id, webRedirectId));
}
