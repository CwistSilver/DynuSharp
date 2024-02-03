using DynuSharp;
using DynuSharp.Authentication;
using DynuSharp.Client;
using DynuSharp.Client.Dns;
using DynuSharp.Client.Domain;
using DynuSharp.Client.Email;
using DynuSharp.Client.Monitor;
using DynuSharp.Client.Ping;

namespace DynuDNS.API;
/// <summary>
/// Provides an implementation for interacting with Dynu services. See API details at <a href="https://www.dynu.com/Support/API" target="_blank">Dynu API</a>.
/// </summary>
public class DynuClient : IDynuClient
{
    private readonly IConnection _connection;

    public IDnsClient DNS { get; private set; }
    public IDomainClient Domain { get; private set; }
    public IMonitorClient Monitor { get; private set; }
    public IPingClient Ping { get; private set; }
    public IEmailClient Email { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DynuClient"/> class using the specified authentication method.
    /// <para>
    /// You can check or create API credentials at 
    /// <a href="https://www.dynu.com/en-US/ControlPanel/APICredentials" target="_blank">
    /// Dynu API Credentials
    /// </a>.
    /// </para>
    /// </summary>
    /// <param name="authentication">The authentication method to use.</param>
    public DynuClient(IAuthentication authentication)
    {
        _connection = new Connection(authentication);

        DNS = new DnsClient(_connection);
        Domain = new DomainClient(_connection);
        Monitor = new MonitorClient(_connection);
        Ping = new PingClient(_connection);
        Email = new EmailClient(_connection);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DynuClient"/> class using an API key for authentication.
    /// <para>
    /// You can check or create API credentials at 
    /// <a href="https://www.dynu.com/en-US/ControlPanel/APICredentials" target="_blank">
    /// Dynu API Credentials
    /// </a>.
    /// </para>
    /// </summary>
    /// <param name="apiKey">The Dynu API key.</param>
    public DynuClient(string apiKey) : this(new ApiKeyAuthentication(apiKey)) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DynuClient"/> class using OAuth2 authentication.
    /// <para>
    /// You can check or create API credentials at 
    /// <a href="https://www.dynu.com/en-US/ControlPanel/APICredentials" target="_blank">
    /// Dynu API Credentials
    /// </a>.
    /// </para>
    /// </summary>
    /// <param name="clientId">The OAuth2 client ID.</param>
    /// <param name="secret">The OAuth2 secret.</param>
    public DynuClient(string clientId, string secret) : this(new OAuth2Authentication(clientId, secret)) { }

    /// <summary>
    /// Finalizes an instance of the <see cref="DynuClient"/> class.
    /// </summary>
    ~DynuClient() => Dispose(false);

    /// <summary>
    /// Whether the <see cref="DynuClient"/> is disposed
    /// </summary>
    protected bool IsDisposed { get; private set; }

    /// <summary>
    /// Releases the resources used by the <see cref="DynuClient"/> class.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the resources used by the <see cref="DynuClient"/> class.
    /// </summary>
    /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
            return;

        if (disposing)
            _connection?.Dispose();

        IsDisposed = true;
    }
}
