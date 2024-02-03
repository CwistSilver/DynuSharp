using System.Text.Json;

namespace DynuSharp.Utilities;
public static class HttpResponseMessageExtention
{
    public static bool IsApiError(this HttpResponseMessage httpResponseMessage) => httpResponseMessage.IsApiErrorAsync().ConfigureAwait(false).GetAwaiter().GetResult();

    public static async Task<bool> IsApiErrorAsync(this HttpResponseMessage httpResponseMessage)
    {
        if (httpResponseMessage.IsSuccessStatusCode)
            return false;

        var content = await httpResponseMessage.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content) || !IsJson(content))
            return false;

        try
        {
            using var doc = JsonDocument.Parse(content);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("type", out var typeElement) && root.TryGetProperty("message", out var messageElement))
                return true;
        }
        catch
        {
            return false;
        }


        return false;
    }

    private static bool IsJson(string input)
    {
        input = input.Trim();
        return input.StartsWith("{") &&
               input.EndsWith("}") ||
               input.StartsWith("[") &&
               input.EndsWith("]");
    }
}
