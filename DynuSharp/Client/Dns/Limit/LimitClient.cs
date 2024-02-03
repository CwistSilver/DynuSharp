using DynuSharp.Client;
using DynuSharp.Data.Limit;

namespace DynuSharp.Client.Dns.Limit;
public sealed class LimitClient : BaseClient, ILimitClient
{
    public const string GetAllPath = "dns/limit";
    public const string GetPath = "dns/{0}/limit";

    private const string JsonPropertyName = "limits";
    public LimitClient(IConnection connection) : base(connection) { }

    public async Task<IReadOnlyList<DnsHostnameLimitData>> GetList() => await Get<List<DnsHostnameLimitData>>(GetAllPath, JsonPropertyName);
    public async Task<IReadOnlyList<DnsRecordLimitData>> GetList(int id) => await Get<List<DnsRecordLimitData>>(string.Format(GetPath, id), JsonPropertyName);
}
