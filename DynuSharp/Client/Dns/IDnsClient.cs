using DynuSharp.Client.Dns.Dnssec;
using DynuSharp.Client.Dns.Domain;
using DynuSharp.Client.Dns.Group;
using DynuSharp.Client.Dns.Limit;
using DynuSharp.Client.Dns.Record;
using DynuSharp.Client.Dns.WebRedirect;
using DynuSharp.Data.Dns;

namespace DynuSharp.Client.Dns;
public interface IDnsClient
{
    /// <summary>
    /// Gets an object to interact with the limit-related functionalities of the DynuDNS service.
    /// </summary>
    ILimitClient Limits { get; }

    /// <summary>
    /// Gets an object to interact with the web redirect functionalities of the DynuDNS service.
    /// <para>
    /// Learn more about
    /// <a href="https://www.dynu.com/Resources/Tutorials/DynamicDNS/Advancedfeatures/WebRedirect" target="_blank">
    /// Web Redirect
    /// </a>.<br/>
    /// You can also learn more about
    /// <a href="https://www.dynu.com/Resources/Tutorials/DynamicDNS/Advancedfeatures/WebRedirect" target="_blank">
    /// Advanced feature Web Redirect
    /// </a>.
    /// </para>
    /// </summary>
    IDnsWebRedirectClient WebRedirects { get; }

    /// <summary>
    /// Gets an object to interact with the DNSSEC (Domain Name System Security Extensions) functionalities of the DynuDNS service.
    /// <para>
    /// Learn more about
    /// <a href="https://www.dynu.com/Resources/DNS-Records/DNSSEC" target="_blank">
    /// DNSSEC
    /// </a>.<br/>
    /// You can also learn more about
    /// <a href="https://www.dynu.com/Resources/Tutorials/DynamicDNS/Advancedfeatures/How-To-Set-Up-DNSSEC" target="_blank">
    /// How to Set Up DNSSEC
    /// </a>.
    /// </para>
    /// </summary>
    IDnssecClient DNSSEC { get; }

    /// <summary>
    /// Gets an object to interact with the DNS record functionalities of the DynuDNS service.
    /// <para>
    /// Learn more about
    /// <a href="https://www.dynu.com/Resources/DNS-Records" target="_blank">
    /// DNS Records
    /// </a>
    /// </para>
    /// </summary>
    IDnsRecordClient Records { get; }

    /// <summary>
    /// Gets an object to interact with the host group functionalities of the DynuDNS service.
    /// </summary>
    IDnsGroupClient Groups { get; }

    /// <summary>
    /// Gets an object to interact with the domain functionalities of the DynuDNS service.
    /// </summary>
    IDnsDomainClient Domains { get; }

    /// <summary>
    /// Retrieves a list of IP address updates.
    /// <para>REQUIRES MEMBERSHIP.</para> 
    /// </summary>
    /// <returns>A list of IP address updates.</returns>
    Task<IReadOnlyList<DnsIpUpdate>> GetIpUpdateHistoryAsync();
}
