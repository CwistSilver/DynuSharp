using DynuSharp.Utilities.Deserializer;
using DynuSharp.Utilities.Extension;
using System.Text.Json;

namespace DynuSharp.Client;
public abstract class BaseClient
{
    protected readonly IConnection _connection;
    internal BaseClient(IConnection connection) => _connection = connection;

    protected async Task Delete(string requestUri)
    {
        var httpClient = await _connection.GetValidHttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, requestUri);
        await httpClient.SendAToApiAsync(requestMessage);
    }

    protected async Task Post(string requestUri, StringContent stringContent)
    {
        var httpClient = await _connection.GetValidHttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = stringContent
        };

        await httpClient.SendAToApiAsync(requestMessage);
    }

    protected async Task<T> Post<T>(string requestUri, StringContent stringContent)
    {
        var httpClient = await _connection.GetValidHttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = stringContent
        };

        return (await httpClient.GetApiResponseAsync<T>(requestMessage)).Data!;
    }

    protected async Task<T> Post<T>(string requestUri, StringContent stringContent, IDeserializer<T> deserializer)
    {
        var httpClient = await _connection.GetValidHttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = stringContent
        };
        var responseData = (await httpClient.GetApiResponseAsync<string>(requestMessage)).Data!;

        var doc = JsonDocument.Parse(responseData);
        return deserializer.Deserialize(doc.RootElement)!;
    }

    protected async Task Get(string requestUri)
    {
        var httpClient = await _connection.GetValidHttpClient();
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
        await httpClient.SendAToApiAsync(requestMessage);
    }

    protected async Task<T> Get<T>(string requestUri, string? dataJsonPropertyName = null)
    {
        var httpClient = await _connection.GetValidHttpClient();
        return (await httpClient.GetApiResponseAsync<T>(requestUri, dataJsonPropertyName)).Data!;
    }

    protected async Task<T> Get<T>(string requestUri, IDeserializer<T> deserializer, string? dataJsonPropertyName = null) where T : class
    {
        var responseData = await Get<string>(requestUri, dataJsonPropertyName);

        var doc = JsonDocument.Parse(responseData!);
        return deserializer.Deserialize<T>(doc.RootElement)!;
    }

    protected async Task<T> Get<T, TBase>(string requestUri, IDeserializer<TBase> deserializer, string? dataJsonPropertyName = null) where T : class, TBase
    {
        var responseData = await Get<string>(requestUri, dataJsonPropertyName);

        var doc = JsonDocument.Parse(responseData);
        return deserializer.Deserialize<T>(doc.RootElement)!;
    }

    protected async Task<List<T>> GetList<T>(string requestUri, IDeserializer<T> deserializer, string? dataJsonPropertyName = null) where T : class
    {
        var responseData = await Get<string>(requestUri, dataJsonPropertyName);

        var doc = JsonDocument.Parse(responseData);
        return deserializer.DeserializeArray(doc.RootElement);
    }

    protected async Task<List<T>> GetList<T, TBase>(string requestUri, IDeserializer<TBase> deserializer, string? dataJsonPropertyName = null) where T : class, TBase
    {
        var responseData = await Get<string>(requestUri, dataJsonPropertyName);

        var doc = JsonDocument.Parse(responseData);
        return deserializer.DeserializeArray<T>(doc.RootElement);
    }
}
