using DynuSharp.Data.Dns;
using DynuSharp.Exceptions;

namespace DynuSharp.Client.Dns.Dnssec;
public interface IDnssecClient
{
    /// <summary>
    /// DS record of DNSSEC for DNS service.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <returns>DS record of DNSSEC</returns>
    Task<DnssecData> Get(int id);

    /// <summary>
    /// Enable DNSSEC for DNS service.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task Enable(int id);

    /// <summary>
    /// Disable DNSSEC for DNS service.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <exception cref="DynuApiException">Thrown when the addition fails due to various reasons such as authentication failure, resource not found, server error, etc.</exception>
    Task Disable(int id);
}
