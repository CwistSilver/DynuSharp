using DynuSharp.Data.Email;

namespace DynuSharp.Client.Email.Whitelist;
/// <summary>
/// Provides methods to interact with the email whitelist.
/// </summary>
public interface IEmailWhitelistClient
{
    /// <summary>
    /// Retrieves a list of whitelisted items.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <returns>A list of whitelisted items.</returns>
    Task<IReadOnlyList<DynuEmailWhitelistItem>> GetListAsync(int id);

    /// <summary>
    /// Retrieves a specific whitelist item.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="whitelistId">The whitelist item ID.</param>
    /// <returns>The whitelist item.</returns>
    Task<DynuEmailWhitelistItem> GetAsync(int id, int whitelistId);

    /// <summary>
    /// Update details of an existing whitelist for email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="whitelistId">The ID of the whitelist item.</param>
    /// <param name="whitelist">The whitelist item to update.</param>
    /// <returns>The updated whitelist item.</returns>
    Task<DynuEmailWhitelistItem> UpdateAsync(int id, int whitelistId, DynuEmailWhitelistItem whitelist);

    /// <summary>
    /// Add a new whitelist for email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="whitelist">The whitelist item to add.</param>
    /// <returns>The added whitelist item.</returns>
    Task<DynuEmailWhitelistItem> AddAsync(int id, DynuEmailWhitelistItem whitelist);

    /// <summary>
    /// Remove a whitelist from email service.
    /// </summary>
    /// <param name="id">The id of the email service.</param>
    /// <param name="whitelistId">The ID of the whitelist item to remove.</param>
    Task DeleteAsync(int id, int whitelistId);
}
