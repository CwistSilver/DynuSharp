using DynuSharp.Client;
using DynuSharp.Data.Domain;

namespace DynuSharp.Client.Domain;
public sealed class DomainClient : BaseClient, IDomainClient
{
    private const string AddPath = "domain/{0}/nameServer/add?nameServer={1}";
    private const string CancelPath = "domain/{0}/cancel";
    private const string DeletePath = "domain/{0}/nameServer?nameServer={1}";
    private const string EnableAutorenewPath = "domain/{0}/autorenewEnable";
    private const string DisableAutorenewPath = "domain/{0}/autorenewDisable";
    private const string GetPath = "domain/{0}";
    private const string GetAllPath = "domain";
    private const string GetDomainNameServersPath = "domain/{0}/nameServer";
    private const string LockPath = "domain/{0}/lock";
    private const string UnlockPath = "domain/{0}/unlock";
    private const string SetPrimaryPath = "domain/{0}/nameServer/primary?nameServer={1}";

    private const string DomainJsonPropertyName = "domains";
    private const string NameServersJsonPropertyName = "nameServers";

    public DomainClient(IConnection connection) : base(connection) { }

    public async Task AddNameServerAsync(int domainId, NameServer nameServer)
        => await Get(string.Format(AddPath, domainId, Uri.EscapeDataString(nameServer.Name)));

    public async Task SetDomainStateToCancelAsync(int domainId)
        => await Get(string.Format(CancelPath, domainId));

    public async Task DeleteNameServerAsync(int domainId, NameServer nameServer)
        => await Delete(string.Format(DeletePath, domainId, Uri.EscapeDataString(nameServer.Name)));

    public async Task DisableAutorenewAsync(int domainId)
        => await Get(string.Format(DisableAutorenewPath, domainId));

    public async Task EnableAutorenewAsync(int domainId)
        => await Get(string.Format(EnableAutorenewPath, domainId));

    public async Task<DomainData> GetAsync(int domainId)
        => await Get<DomainData>(string.Format(GetPath, domainId));

    public async Task<IReadOnlyList<DomainData>> GetListAsync()
        => await Get<List<DomainData>>(GetAllPath, DomainJsonPropertyName);

    public async Task<IReadOnlyList<NameServer>> GetNameServerListAsync(int domainId)
        => await Get<List<NameServer>>(string.Format(GetDomainNameServersPath, domainId), NameServersJsonPropertyName);

    public async Task LockAsync(int domainId)
        => await Get(string.Format(LockPath, domainId));

    public async Task SetNameServerPrimaryAsync(int domainId, NameServer nameServer)
        => await Get(string.Format(SetPrimaryPath, domainId, Uri.EscapeDataString(nameServer.Name)));

    public async Task UnlockAsync(int domainId)
        => await Get(string.Format(UnlockPath, domainId));
}