using DynuSharp.Data.Email;

namespace DynuSharp.Client.Email.Blacklist;
/// <summary>
/// Provides methods to interact with the email blacklist.
/// </summary>
public interface IEmailBlacklistClient
{
    /// <summary>
    /// Get a list of blacklist.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <returns>A list of blacklist items.</returns>
    Task<IReadOnlyList<DynuEmailBlacklistItem>> GetListAsync(int id);

    /// <summary>
    /// Retrieves a specific blacklist item.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="blacklistId">The blacklist item ID.</param>
    /// <returns>The blacklist item.</returns>
    Task<DynuEmailBlacklistItem> GetAsync(int id, int blacklistId);

    /// <summary>
    /// Update details of an existing blacklist for email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="blacklistId">The id of the blacklist for email service.</param>
    /// <param name="blacklist">The blacklist item to update.</param>
    /// <returns>The updated blacklist item.</returns>
    Task<DynuEmailBlacklistItem> UpdateAsync(int id, int blacklistId, DynuEmailBlacklistItem blacklist);

    /// <summary>
    /// Add a new blacklist for email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="blacklist">The blacklist item to add.</param>
    /// <returns>The added blacklist item.</returns>
    Task<DynuEmailBlacklistItem> AddAsync(int id, DynuEmailBlacklistItem blacklist);

    /// <summary>
    /// Remove a blacklist from email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="blacklistId">The id of the blacklist for email service.</param>
    Task DeleteAsync(int id, int blacklistId);
}
