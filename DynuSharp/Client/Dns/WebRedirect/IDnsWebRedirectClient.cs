using DynuSharp.Data.DnsWebRedirect;
using DynuSharp.Exceptions;

namespace DynuSharp.Client.Dns.WebRedirect;
public interface IDnsWebRedirectClient
{
    /// <summary>
    /// Get details of the web redirect.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// /// <param name="id">The id of the web redirect.</param>
    /// <returns>Details of the web redirect.</returns>
    Task<DnsWebRedirectBase> GetAsync(int id, int webRedirectId);

    /// <summary>
    /// Get details of the web redirect.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// /// <param name="id">The id of the web redirect.</param>
    /// <returns>Details of the web redirect.</returns>
    Task<T> GetAsync<T>(int id, int webRedirectId) where T : DnsWebRedirectBase;

    /// <summary>
    /// Get a list of web redirects.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <returns>A list of web redirects.</returns>
    Task<IReadOnlyList<DnsWebRedirectBase>> GetListAsync(int id);

    /// <summary>
    /// Add a new web redirect.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="dnsWebRedirect">Data of the web redirect to be added.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsWebRedirectBase> AddAsync(int id, DnsWebRedirectBase dnsWebRedirect);

    /// <summary>
    /// Update an existing web redirect.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="webRedirectId">The id of the web redirect.</param>
    /// <param name="dnsWebRedirect">Data of the web redirect to be added.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task<DnsWebRedirectBase> UpdateAsync(int id, int webRedirectId, DnsWebRedirectBase dnsWebRedirect);

    /// <summary>
    /// Remove a web redirect.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <param name="webRedirectId">The id of the web redirect.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DeleteAsync(int id, int webRedirectId);
}