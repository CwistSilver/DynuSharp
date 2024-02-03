using DynuSharp.Client.Email.Blacklist;
using DynuSharp.Client.Email.Whitelist;
using DynuSharp.Utilities.Deserializer;
using DynuSharp.Client.Email.Blacklist;
using DynuSharp.Client.Email.Whitelist;
using DynuSharp.Data.Email;
using DynuSharp.Data.Email.Type;
using DynuSharp.Utilities.Deserializer;

namespace DynuSharp.Client.Email;
public sealed class EmailClient : BaseClient, IEmailClient
{
    private const string GetAllPath = "email";
    private const string GetPath = "email/{0}";
    private const string GetDeliveryPath = "email/{0}/deliveryQueue";

    private const string JsonPropertyName = "emails";
    private const string DomainsJsonPropertyName = "domains";

    private readonly IDeserializer<DynuEmailServiceBase> _emailDeserializer;

    public IEmailBlacklistClient Blacklist { get; private set; }
    public IEmailWhitelistClient Whitelist { get; private set; }

    public EmailClient(IConnection connection) : base(connection)
    {
        _emailDeserializer = new GenericDeserializer<DynuEmailServiceBase, EmailType>(nameof(DynuEmailServiceBase.Type), nameof(DynuEmailServiceBase.Type).ToLower());

        Blacklist = new EmailBlacklistClient(connection);
        Whitelist = new EmailWhitelistClient(connection);
    }

    public async Task<DynuEmailServiceBase> GetAsync(int id)
        => await Get(string.Format(GetPath, id), _emailDeserializer);

    public async Task<T> GetAsync<T>(int id) where T : DynuEmailServiceBase
        => await Get<T, DynuEmailServiceBase>(string.Format(GetPath, id), _emailDeserializer);

    public async Task<IReadOnlyList<QueuedEmailMessage>> GetDeliveryQueueAsync(int id)
        => await Get<List<QueuedEmailMessage>>(string.Format(GetDeliveryPath, id), DomainsJsonPropertyName);

    public async Task<IReadOnlyList<DynuEmailServiceBase>> GetListAsync()
        => await GetList(GetAllPath, _emailDeserializer, JsonPropertyName);
}
