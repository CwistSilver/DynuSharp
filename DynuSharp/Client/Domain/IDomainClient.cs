using DynuSharp.Data.Domain;
using DynuSharp.Exceptions;

namespace DynuSharp.Client.Domain;
public interface IDomainClient
{
    /// <summary>
    /// Get a list of domains for domain registration service.
    /// </summary>
    /// <returns> A list of domains.</returns>
    Task<IReadOnlyList<DomainData>> GetListAsync();

    /// <summary>
    /// Get details of a domain registration domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <returns> Details of a domain.</returns>
    Task<DomainData> GetAsync(int domainId);

    /// <summary>
    /// Add a name server to a domain.
    /// Predefined NameServers can be found here <see cref="NameServers"/> class.
    /// <para>
    /// Check the available 
    /// <a href="https://www.dynu.com/en-US/DynamicDNS#:~:text=Top%20level%20domain%20name%20(yourname.com)" target="_blank">
    /// Name servers
    /// </a>.
    /// </para>
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <param name="nameServer">The name server to add to the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task AddNameServerAsync(int domainId, NameServer nameServer);

    /// <summary>
    /// Delete a name server of a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <param name="nameServer">The name server to add to the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DeleteNameServerAsync(int domainId, NameServer nameServer);

    /// <summary>
    /// Make a name server the primary name server of a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <param name="nameServer">The name server to add to the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task SetNameServerPrimaryAsync(int domainId, NameServer nameServer);

    /// <summary>
    /// Cancel a domain.
    /// <para>
    /// Careful: it can not be reversed without contacting customer service.
    /// </para>
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task SetDomainStateToCancelAsync(int domainId);

    /// <summary>
    /// Get a list of name servers for a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <returns> A list of name servers for a domain.</returns>
    Task<IReadOnlyList<NameServer>> GetNameServerListAsync(int domainId);

    /// <summary>
    /// Enable autorenewal for a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task EnableAutorenewAsync(int domainId);

    /// <summary>
    /// Disable autorenewal for a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task DisableAutorenewAsync(int domainId);

    /// <summary>
    /// Lock a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task LockAsync(int domainId);

    /// <summary>
    /// Unlock a domain.
    /// </summary>
    /// <param name="domainId">The id of the domain.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task UnlockAsync(int domainId);
}
