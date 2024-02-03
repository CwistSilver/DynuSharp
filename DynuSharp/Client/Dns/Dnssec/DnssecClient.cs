using DynuSharp.Client;
using DynuSharp.Data.Dns;

namespace DynuSharp.Client.Dns.Dnssec;
public sealed class DnssecClient : BaseClient, IDnssecClient
{
    public const string GetPath = "dns/{0}/dnssec";
    public const string EnablePath = "dns/{0}/dnssec/enable";
    public const string DisablePath = "dns/{0}/dnssec/disable";

    public DnssecClient(IConnection connection) : base(connection) { }

    public async Task<DnssecData> Get(int id) => await Get<DnssecData>(string.Format(GetPath, id));
    public async Task Enable(int id) => await Get(string.Format(EnablePath, id));
    public async Task Disable(int id) => await Get(string.Format(DisablePath, id));
}
