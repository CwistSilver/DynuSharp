using DynuSharp.Data.Dns;

namespace DynuSharp.Client.Dns.Domain;
public interface IDnsDomainClient
{
    /// <summary>
    /// Get the root domain name based on a hostname.
    /// </summary>
    /// <param name="hostname">The child hostname of the domain for DNS service.</param>
    /// <returns>Root domain of DNS service along with the hostname and node.</returns>
    Task<RootDnsDomain> GetRootAsync(string hostname);

    /// <summary>
    /// Get a list of domains for DNS service.
    /// </summary>
    /// <returns>A list of domains for DNS service.</returns>
    Task<IReadOnlyList<DnsDomain>> GetListAsync();

    /// <summary>
    /// Get details of a domain for DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <returns>Details of a domain for DNS service.</returns>
    Task<DnsDomain> GetAsync(int id);

    /// <summary>
    /// Add a new DNS service.
    /// </summary>
    /// <param name="dnsDomain">Detailed data of the domain to be added for DNS service.</param>
    /// <exception cref="Exceptions.DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task AddAsync(DnsDomain dnsDomain);

    /// <summary>
    /// Update an existing DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="dnsDomain">Detailed data of the domain to be updated for DNS service.</param>
    /// <exception cref="Exceptions.DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task UpdateAsync(int id, DnsDomain dnsDomain);

    /// <summary>
    /// Remove domain from DNS service.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <exception cref="Exceptions.DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DeleteAsync(int id);
}
