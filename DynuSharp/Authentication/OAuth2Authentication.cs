using DynuSharp.Data.Authentication;
using DynuSharp.Security;
using DynuSharp.Utilities.Extension;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;

namespace DynuSharp.Authentication;

/// <summary>
/// Provides methods and properties for handling OAuth 2.0 authentication.
/// </summary>
public sealed class OAuth2Authentication : IAuthentication
{
    private readonly string _clientIdEnvironmentKey;
    private readonly string _secretEnvironmentKey;
    private readonly ISecureMemoryStorage _secureMemoryStorage;
    private DateTime _expiredAt = DateTime.MinValue;

    public bool IsExpired => _expiredAt <= DateTime.UtcNow;

    private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
    private readonly SemaphoreSlim _refreshSemaphoreSlim = new(1, 1);

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuth2Authentication"/> class with specified client ID and secret.
    /// </summary>
    /// <param name="clientId">The client ID used for OAuth 2.0 authentication.</param>
    /// <param name="secret">The secret key used for OAuth 2.0 authentication.</param>
    public OAuth2Authentication(string clientId, string secret)
    {
        _secureMemoryStorage = new SecureMemoryStorage();
        _clientIdEnvironmentKey = _secureMemoryStorage.Add(clientId);
        _secretEnvironmentKey = _secureMemoryStorage.Add(secret);
    }

    public OAuth2Authentication(string clientId, string secret, ISecureMemoryStorage secureMemoryStorage)
    {
        _secureMemoryStorage = secureMemoryStorage;
        _clientIdEnvironmentKey = _secureMemoryStorage.Add(clientId);
        _secretEnvironmentKey = _secureMemoryStorage.Add(secret);
    }

    public async Task AddHeadersToClient(HttpClient client) => await SetAuthentication(client);

    /// <summary>
    /// Refreshes the OAuth2 authentication headers for the given HttpClient instance.
    /// </summary>
    /// <param name="client">The HttpClient instance to refresh the authentication for.</param>
    /// <exception cref="AuthenticationException">
    /// Thrown when there is an issue in retrieving a valid access token from Dynu. This can occur due
    /// to unauthorized access (wrong credentials) or other issues with the token endpoint response.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// Thrown when there is a communication error with the Dynu server.
    /// </exception>
    /// <exception cref="JsonException">
    /// Thrown when there is an issue deserializing the response from Dynu.
    /// </exception>
    public async Task RefreshAuthentication(HttpClient client)
    {
        await _refreshSemaphoreSlim.WaitAsync();

        try
        {
            foreach (var header in client.DefaultRequestHeaders)
            {
                if (header.Key.Contains(AuthenticationHeader.OAuth2Header))
                    client.DefaultRequestHeaders.Remove(header.Key);
            }

            await SetAuthentication(client);
        }
        finally
        {
            _refreshSemaphoreSlim.Release();
        }
    }

    private async Task SetAuthentication(HttpClient client)
    {
        await _semaphoreSlim.WaitAsync();

        try
        {
            var oAuth2Reponse = await GetAccesToken(client);
            _expiredAt = DateTime.UtcNow.AddSeconds(oAuth2Reponse.ExpiresIn);

            var tokenType = oAuth2Reponse.TokenType.FirstCharToUpper();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, oAuth2Reponse.AccessToken);
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    private async Task<OAuth2Reponse> GetAccesToken(HttpClient client)
    {
        try
        {
            var clientId = _secureMemoryStorage.Get<string>(_clientIdEnvironmentKey);
            var secret = _secureMemoryStorage.Get<string>(_secretEnvironmentKey);

            var byteArray = Encoding.ASCII.GetBytes($"{new Guid(clientId)}:{secret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await client.GetAsync("oauth2/token");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new AuthenticationException("Unauthorized access. Please verify your credentials and try again.");

            if (!response.IsSuccessStatusCode)
                throw new AuthenticationException($"HttpCode: {response.StatusCode} Failed to retrieve valid access token from Dynu.");

            var oAuth2Reponse = await response.Content.ReadFromJsonAsync<OAuth2Reponse>();
            if (oAuth2Reponse is null || oAuth2Reponse.AccessToken is null)
                throw new AuthenticationException("Failed to retrieve valid access token from Dynu.");

            return oAuth2Reponse;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception("There was an error communicating with the Dynu server.", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception("Failed to deserialize the response from Dynu.", ex);
        }
    }

    public void Dispose()
    {
        _secureMemoryStorage.Dispose();
        _semaphoreSlim.Dispose();
    }
}