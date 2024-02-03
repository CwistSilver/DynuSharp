using DynuSharp.Data.Email;
using DynuSharp.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Client.Email.Whitelist;
public sealed class EmailWhitelistClient : BaseClient, IEmailWhitelistClient
{
    private const string GetAllPath = "email/{0}/whitelist";
    private const string GetPath = "email/{0}/whitelist/{1}";
    private const string UpdatePath = "email/{0}/whitelist/{1}";
    private const string AddPath = "email/{0}/whitelist";
    private const string DeletePath = "email/{0}/whitelist/{1}";

    private const string JsonPropertyName = "whitelists";

    public EmailWhitelistClient(IConnection connection) : base(connection) { }

    public async Task DeleteAsync(int id, int whitelistId)
        => await Delete(string.Format(DeletePath, id, whitelistId));

    public async Task<DynuEmailWhitelistItem> GetAsync(int id, int whitelistId)
        => await Get<DynuEmailWhitelistItem>(string.Format(GetPath, id, whitelistId));

    public async Task<IReadOnlyList<DynuEmailWhitelistItem>> GetListAsync(int id)
        => await Get<List<DynuEmailWhitelistItem>>(string.Format(GetAllPath, id), JsonPropertyName);

    public async Task<DynuEmailWhitelistItem> UpdateAsync(int id, int whitelistId, DynuEmailWhitelistItem whitelist)
    {
        var content = new StringContent(JsonSerializer.Serialize(whitelist, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DynuEmailWhitelistItem>(string.Format(UpdatePath, id, whitelistId), content);
    }

    public async Task<DynuEmailWhitelistItem> AddAsync(int id, DynuEmailWhitelistItem whitelist)
    {
        var content = new StringContent(JsonSerializer.Serialize(whitelist, GloabalJsonOptions.Options), Encoding.UTF8, "application/json");
        return await Post<DynuEmailWhitelistItem>(string.Format(AddPath, id), content);
    }
}
