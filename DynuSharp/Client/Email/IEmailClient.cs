using DynuSharp.Client.Email.Blacklist;
using DynuSharp.Client.Email.Whitelist;
using DynuSharp.Data.Email;
using DynuSharp.Data.Email.Type;

namespace DynuSharp.Client.Email;
/// <summary>
/// Manages email functionalities in the Dynu API.
/// </summary>
public interface IEmailClient
{
    /// <summary>
    /// Provides interaction with the email blacklist.
    /// </summary>
    IEmailBlacklistClient Blacklist { get; }

    /// <summary>
    /// Provides interaction with the email whitelist.
    /// </summary>
    IEmailWhitelistClient Whitelist { get; }

    /// <summary>
    /// Get a list of email services.
    /// </summary>
    /// <returns>A list of email services.</returns>
    Task<IReadOnlyList<DynuEmailServiceBase>> GetListAsync();

    /// <summary>
    /// Get details of an email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <returns>Details of an email service.</returns>
    Task<DynuEmailServiceBase> GetAsync(int id);

    /// <summary>
    /// Gets a specific email service by ID with type casting asynchronously.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <typeparam name="T">Service type.</typeparam>
    /// <returns>Typed email service details.</returns>
    Task<T> GetAsync<T>(int id) where T : DynuEmailServiceBase;

    /// <summary>
    /// Get a list of messages in delivery queue.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <returns>A list of messages in delivery queue.</returns>
    Task<IReadOnlyList<QueuedEmailMessage>> GetDeliveryQueueAsync(int id);

}
