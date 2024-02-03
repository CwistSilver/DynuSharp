using DynuSharp.Client.Dns;
using DynuSharp.Client.Domain;
using DynuSharp.Client.Email;
using DynuSharp.Client.Monitor;
using DynuSharp.Client.Ping;

namespace DynuSharp;
/// <summary>
/// Provides interfaces to interact with Dynu services. See API details at <a href="https://www.dynu.com/Support/API" target="_blank">Dynu API</a>.
/// </summary>
public interface IDynuClient : IDisposable
{
    /// <summary>
    /// Manages email functionalities. For more information, see <a href="https://www.dynu.com/en-US/Email" target="_blank">Dynu Email Services</a>.
    /// </summary>
    IEmailClient Email { get; }

    /// <summary>
    /// Manages DNS settings and records. Detailed information at <a href="https://www.dynu.com/en-US/DynamicDNS" target="_blank">Dynamic DNS</a>.
    /// </summary>
    IDnsClient DNS { get; }

    /// <summary>
    /// Provides domain management functionalities.
    /// </summary>
    IDomainClient Domain { get; }

    /// <summary>
    /// Offers monitoring services to ensure operational integrity and availability.
    /// </summary>
    IMonitorClient Monitor { get; }

    /// <summary>
    /// Enables testing of network connectivity and latency with ping services.
    /// </summary>
    IPingClient Ping { get; }
}