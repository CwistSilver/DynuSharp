using DynuSharp.Data.Dns;
using DynuSharp.Exceptions;

namespace DynuSharp.Client.Dns.Group;
public interface IDnsGroupClient
{
    /// <summary>
    /// Get a list of groups to which hosts are assigned to.
    /// </summary>
    /// <returns>A list of groups to which hosts are assigned to.</returns>
    Task<IReadOnlyList<DnsGroup>> GetListAsync();

    /// <summary>
    /// Add a new group.
    /// </summary>
    /// <param name="dnsGroup">The DNS group to add.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsGroup> AddAsync(DnsGroup dnsGroup);

    /// <summary>
    /// Update an existing group.
    /// </summary>
    /// <param name="id">The id of the group.</param>
    /// <param name="dnsGroup">The DNS group data to update.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsGroup> UpdateAsync(int id, DnsGroup dnsGroup);

    /// <summary>
    /// Remove a group.
    /// </summary>
    /// <param name="id">The id of the group.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DeleteAsync(int id);
}
