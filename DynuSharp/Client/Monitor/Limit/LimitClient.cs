using DynuSharp.Client;
using DynuSharp.Data.Limit;

namespace DynuSharp.Client.Monitor.Limit;
public sealed class LimitClient : BaseClient, ILimitClient
{
    private const string GetPath = "monitor/limit";

    public LimitClient(IConnection connection) : base(connection) { }

    public async Task<LimitBase> Get()
        => await Get<LimitBase>(GetPath);
}
