using DynuSharp.Client.Monitor.Limit;
using DynuSharp.Data.Monitor;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Monitor;
public sealed class MonitorClient : BaseClient, IMonitorClient
{
    private const string AddPath = "monitor";
    private const string GetAllPath = "monitor";
    private const string DeletePath = "monitor/{0}";
    private const string GetPath = "monitor/{0}";
    private const string PausePath = "monitor/{0}/pause";
    private const string UnpausePath = "monitor/{0}/unpause";

    private const string JsonPropertyName = "monitors";

    private readonly IDeserializer<MonitorBase> _monitorDeserializer;

    public ILimitClient Limits { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="IDomainClient"/> class using the specified authentication method.
    /// </summary>
    /// <param name="connection">The Dynu connection to use.</param>
    public MonitorClient(IConnection connection) : base(connection)
    {
        _monitorDeserializer = new GenericDeserializer<MonitorBase, MonitorType>(nameof(MonitorBase.Type), nameof(MonitorBase.Type).ToLower());
        Limits = new LimitClient(_connection);
    }

    public async Task AddAsync(MonitorBase monitorBase)
    {
        var content = new StringContent(JsonSerializer.Serialize(monitorBase, monitorBase.GetType(), GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        await Post(AddPath, content);
    }

    public async Task DeleteAsync(int id)
        => await Delete(string.Format(DeletePath, id));

    public async Task<MonitorBase> GetAsync(int id)
        => await Get(string.Format(GetPath, id), _monitorDeserializer);

    public async Task<IReadOnlyList<MonitorBase>> GetListAsync()
        => await GetList(GetAllPath, _monitorDeserializer, JsonPropertyName);

    public async Task PauseAsync(int id)
        => await Get(string.Format(PausePath, id));

    public async Task UnpauseAsync(int id)
        => await Get(string.Format(UnpausePath, id));
}