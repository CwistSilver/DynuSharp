using DynuSharp.Authentication;
using DynuSharp.Utilities;
using Microsoft.Extensions.Http;
using Polly;
using System.Net.Http.Headers;

namespace DynuSharp.Client;
public sealed class Connection : IConnection
{
    public const string ApiHelpLink = "https://www.dynu.com/Support/API";
    public const string BaseAddress = "https://api.dynu.com/v2/";

    private readonly Lazy<Task<HttpClient>> _lazyHttpClient;
    private readonly IAuthentication _authentication;

    /// <summary>
    /// Initializes a new instance of the Connection class with a specified authentication mechanism.
    /// </summary>
    /// <param name="authentication">An authentication implementation to use for securing API connections.</param>
    public Connection(IAuthentication authentication)
    {
        _authentication = authentication;
        _lazyHttpClient = new Lazy<Task<HttpClient>>(CreateAndInitializeHttpClientAsync);
    }

    private async Task<HttpClient> CreateAndInitializeHttpClientAsync()
    {
        var retryPolicy = Policy
             .HandleResult<HttpResponseMessage>(r => false)
             .OrResult(message =>
             {
                 if (message.IsSuccessStatusCode)
                     return false;

                 if (message.IsApiError())
                     return false;

                 return true;
             })
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));


        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15)
        };

        var policyHandler = new PolicyHttpMessageHandler(retryPolicy)
        {
            InnerHandler = handler,
        };

        var client = new HttpClient(policyHandler)
        {
            BaseAddress = new Uri(BaseAddress)
        };

        var version = System.Reflection.Assembly.GetAssembly(typeof(Connection))?.GetName().Version?.ToString() ?? "1.0.0";
        client.DefaultRequestHeaders.UserAgent.ParseAdd($"DynuClient/{version} (https://github.com/CwistSilver/DynuSharp)");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.ExpectContinue = false;
        client.DefaultRequestHeaders.ConnectionClose = false;

        await _authentication.AddHeadersToClient(client);
        return client;
    }

    /// <summary>
    /// Retrieves a valid HTTP client, renewing the authentication if necessary.
    /// </summary>
    /// <returns>An HttpClient instance configured with the necessary authentication and base address.</returns>
    public async Task<HttpClient> GetValidHttpClient()
    {
        var httpClient = await _lazyHttpClient.Value;
        if (_authentication.IsExpired)
            await _authentication.RefreshAuthentication(httpClient);

        return httpClient;
    }

    public void Dispose()
    {
        if (_lazyHttpClient.IsValueCreated)
            _lazyHttpClient.Value.Result.Dispose();

        _authentication.Dispose();
    }
}
