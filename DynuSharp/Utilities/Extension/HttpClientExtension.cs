using DynuSharp.Data;

namespace DynuSharp.Utilities.Extension;
internal static class HttpClientExtension
{
    internal static async Task SendAToApiAsync(this HttpClient client, HttpRequestMessage requestMessage)
    {
        var responseString = await SendRequestAndGetResponseStringAsync(client, requestMessage);
        CreateApiResponse<string>(responseString, null, false);
    }

    internal static async Task<ApiResponse<T>> GetApiResponseAsync<T>(this HttpClient client, HttpRequestMessage requestMessage, string? dataJsonPropertyName = null, bool containsData = true)
    {
        var responseString = await SendRequestAndGetResponseStringAsync(client, requestMessage);
        return CreateApiResponse<T>(responseString, dataJsonPropertyName, containsData);
    }

    internal static async Task<ApiResponse<T>> GetApiResponseAsync<T>(this HttpClient client, string requestUri, string? dataJsonPropertyName = null, bool containsData = true)
    {
        var responseString = await SendRequestAndGetResponseStringAsync(client, new HttpRequestMessage(HttpMethod.Get, requestUri));
        return CreateApiResponse<T>(responseString, dataJsonPropertyName, containsData);
    }

    private static async Task<string> SendRequestAndGetResponseStringAsync(HttpClient client, HttpRequestMessage requestMessage)
    {
        var httpResponse = await client.SendAsync(requestMessage);
        return await httpResponse.Content.ReadAsStringAsync();
    }

    private static ApiResponse<T> CreateApiResponse<T>(string responseString, string? dataJsonPropertyName, bool containsData)
    {
        var response = new ApiResponse<T>().Deserialize(responseString, dataJsonPropertyName, containsData);

        if (response?.StatusCode == 200)
            return response;
        else if (response?.Error is not null)
            throw response.Error;
        else
            throw new Exception("Unknown error");
    }
}