using DynuSharp.Client.Dns.Dnssec;
using DynuSharp.Client.Dns.Domain;
using DynuSharp.Client.Dns.WebRedirect;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Client;
using DynuSharp.Client.Dns.Dnssec;
using DynuSharp.Client.Dns.Domain;
using DynuSharp.Client.Dns.Group;
using DynuSharp.Client.Dns.Limit;
using DynuSharp.Client.Dns.Record;
using DynuSharp.Client.Dns.WebRedirect;
using DynuSharp.Data.Dns;
using DynuSharp.Data.Dns.Record;
using DynuSharp.Data.DnsWebRedirect;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Extension;

namespace DynuSharp.Client.Dns;
public sealed class DnsClient : BaseClient, IDnsClient
{
    private const string GetHistoryPath = "dns/ipUpdateHistory";

    private const string JsonPropertyName = "ipUpdateHistory";

    private readonly IDeserializer<DnsRecordBase> _dnsRecordDeserializer;
    private readonly IDeserializer<DnsWebRedirectBase> _webRedirectDeserializer;

    public ILimitClient Limits { get; private set; }
    public IDnsWebRedirectClient WebRedirects { get; private set; }
    public IDnssecClient DNSSEC { get; private set; }
    public IDnsRecordClient Records { get; private set; }
    public IDnsGroupClient Groups { get; private set; }
    public IDnsDomainClient Domains { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DnsClient"/> class using the specified authentication method.
    /// </summary>
    /// <param name="connection">The Dynu connection to use.</param>
    public DnsClient(IConnection connection) : base(connection)
    {
        _dnsRecordDeserializer = new GenericDeserializer<DnsRecordBase, RecordType>(nameof(DnsRecordBase.RecordType), nameof(DnsRecordBase.RecordType).FirstCharToLower());
        _webRedirectDeserializer = new GenericDeserializer<DnsWebRedirectBase, RedirectType>(nameof(DnsWebRedirectBase.RedirectType), nameof(DnsWebRedirectBase.RedirectType).FirstCharToLower());

        Limits = new LimitClient(_connection);
        WebRedirects = new DnsWebRedirectClient(_connection, _webRedirectDeserializer);
        DNSSEC = new DnssecClient(_connection);
        Records = new DnsRecordClient(_connection, _dnsRecordDeserializer);
        Groups = new DnsGroupClient(_connection);
        Domains = new DnsDomainClient(_connection);
    }

    public async Task<IReadOnlyList<DnsIpUpdate>> GetIpUpdateHistoryAsync() => await Get<List<DnsIpUpdate>>(GetHistoryPath, JsonPropertyName);
}
