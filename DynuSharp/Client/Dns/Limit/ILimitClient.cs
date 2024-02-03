using DynuSharp.Data.Limit;

namespace DynuSharp.Client.Dns.Limit;
public interface ILimitClient
{
    /// <summary>
    /// Limits associated with hostnames.
    /// </summary>
    /// <returns>Limits associated with hostnames.</returns>
    Task<IReadOnlyList<DnsHostnameLimitData>> GetList();

    /// <summary>
    /// Limits associated with DNS records.
    /// </summary>
    /// <param name="id">The id of the domain for DNS service.</param>
    /// <returns>Limits associated with DNS records.</returns>
    Task<IReadOnlyList<DnsRecordLimitData>> GetList(int id);
}
