using DynuSharp.Data.Dns.Record;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Dns.Record;
public sealed class DnsRecordClient : BaseClient, IDnsRecordClient
{
    private const string GetAllPath = "dns/{0}/record";
    private const string GetPath = "dns/{0}/record/{1}";
    private const string GetFromHostPath = "dns/record/{0}?recordType={1}";
    private const string AddPath = "dns/{0}/record";
    private const string UpdatePath = "dns/{0}/record/{1}";
    private const string DeletePath = "dns/{0}/record/{1}";

    private const string JsonPropertyName = "dnsRecords";

    private readonly IDeserializer<DnsRecordBase> _dnsRecordDeserializer;
    public DnsRecordClient(IConnection connection, IDeserializer<DnsRecordBase> dnsRecordDeserializer) : base(connection) => _dnsRecordDeserializer = dnsRecordDeserializer;

    public async Task<IReadOnlyList<DnsRecordBase>> GetListAsync(int id)
        => await GetList(string.Format(GetAllPath, id), _dnsRecordDeserializer, JsonPropertyName);

    public async Task<T> GetAsync<T>(int id, int recordId) where T : DnsRecordBase
        => await Get<T, DnsRecordBase>(string.Format(GetPath, id, recordId), _dnsRecordDeserializer);

    public async Task<DnsRecordBase> GetAsync(int id, int recordId)
        => await Get(string.Format(GetPath, id, recordId), _dnsRecordDeserializer);

    public async Task<IReadOnlyList<DnsRecordBase>> GetListOfTypeAsync(string recordHostname, RecordType recordType)
    {
        var uri = string.Format(GetFromHostPath, recordHostname, Uri.EscapeDataString(recordType.ToString()));
        return await GetList(uri, _dnsRecordDeserializer, JsonPropertyName);
    }

    public async Task<IReadOnlyList<T>> GetListOfTypeAsync<T>(string recordHostname) where T : DnsRecordBase
    {
        if (typeof(T) == typeof(DnsRecordBase))
            throw new ArgumentException("T cannot be of type DnsRecordBase. Please provide a derived type.");

        var instance = Activator.CreateInstance(typeof(T)) as DnsRecordBase;
        var uri = string.Format(GetFromHostPath, recordHostname, Uri.EscapeDataString(instance!.RecordType.ToString()));
        return await GetList<T, DnsRecordBase>(uri, _dnsRecordDeserializer, JsonPropertyName);
    }

    public async Task<DnsRecordBase> AddAsync(int id, DnsRecordBase dnsRecord)
    {
        var uri = string.Format(AddPath, id);
        var content = new StringContent(JsonSerializer.Serialize(dnsRecord, dnsRecord.GetType(), GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post(uri, content, _dnsRecordDeserializer);
    }

    public async Task<DnsRecordBase> UpdateAsync(int id, int recordId, DnsRecordBase dnsRecord)
    {
        var uri = string.Format(UpdatePath, id, recordId);
        var content = new StringContent(JsonSerializer.Serialize(dnsRecord, dnsRecord.GetType(), GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post(uri, content, _dnsRecordDeserializer);
    }

    public async Task DeleteAsync(int id, int recordId) => await Delete(string.Format(DeletePath, id, recordId));
}
