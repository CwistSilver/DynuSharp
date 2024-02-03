using DynuSharp.Data.Email;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Email.Blacklist;
public sealed class EmailBlacklistClient : BaseClient, IEmailBlacklistClient
{
    private const string DeletePath = "email/{0}/blacklist/{1}";
    private const string GetPath = "email/{0}/blacklist/{1}";
    private const string GetAllPath = "email/{0}/blacklist";
    private const string UpdatePath = "email/{0}/blacklist/{1}";
    private const string AddPath = "email/{0}/blacklist";

    private const string JsonPropertyName = "blacklists";

    public EmailBlacklistClient(IConnection connection) : base(connection) { }

    public async Task DeleteAsync(int id, int blacklistId)
        => await Delete(string.Format(DeletePath, id, blacklistId));

    public async Task<DynuEmailBlacklistItem> GetAsync(int id, int blacklistId)
        => await Get<DynuEmailBlacklistItem>(string.Format(GetPath, id, blacklistId));

    public async Task<IReadOnlyList<DynuEmailBlacklistItem>> GetListAsync(int id)
        => await Get<List<DynuEmailBlacklistItem>>(string.Format(GetAllPath, id), JsonPropertyName);

    public async Task<DynuEmailBlacklistItem> UpdateAsync(int id, int blacklistId, DynuEmailBlacklistItem blacklist)
    {
        var content = new StringContent(JsonSerializer.Serialize(blacklist, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DynuEmailBlacklistItem>(string.Format(UpdatePath, id, blacklistId), content);
    }

    public async Task<DynuEmailBlacklistItem> AddAsync(int id, DynuEmailBlacklistItem blacklist)
    {
        var content = new StringContent(JsonSerializer.Serialize(blacklist, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DynuEmailBlacklistItem>(string.Format(AddPath, id), content);
    }
}
