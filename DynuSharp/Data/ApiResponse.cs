using DynuSharp.Exceptions;
using DynuSharp.Utilities.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Data;
internal sealed class ApiResponse<T>
{
    [JsonPropertyName("statusCode")]
    internal int StatusCode { get; set; }
    internal T? Data { get; set; }
    internal ApiError? ErrorDetails { get; set; }

    internal bool IsSuccessStatusCode => StatusCode >= 200 && StatusCode <= 299;

    [JsonIgnore]
    internal DynuApiException? Error { get; private set; }

    internal ApiResponse<T> Deserialize(string json, string? dataJsonPropertyName = null, bool containsData = true)
    {
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        var response = new ApiResponse<T>
        {
            StatusCode = root.GetProperty("statusCode").GetInt32()
        };

        if (!response.IsSuccessStatusCode)
        {
            ExtractErrorDetails(root, response);
            return response;
        }


        if (containsData)
            ExtractData(root, response, dataJsonPropertyName);

        return response;
    }

    private static void ExtractErrorDetails(JsonElement root, ApiResponse<T> response)
    {
        if (root.TryGetProperty("type", out var typeElement) && root.TryGetProperty("message", out var messageElement))
        {
            response.ErrorDetails = new ApiError
            {
                StatusCode = response.StatusCode,
                Type = typeElement.GetString()!,
                Message = messageElement.GetString()!
            };

            MapErrorToException(response);
        }
    }

    private static void ExtractData(JsonElement root, ApiResponse<T> response, string? dataJsonPropertyName)
    {
        if (!string.IsNullOrEmpty(dataJsonPropertyName) && root.TryGetProperty(dataJsonPropertyName, out var dataElement))
        {
            if (typeof(T) == typeof(string))
            {
                var text = dataElement.GetRawText();
                response.Data = (T)(object)text;
            }
            else
            {
                response.Data = JsonSerializer.Deserialize<T>(dataElement.GetRawText(), GloabalJsonOptions.OptionsForDeserialize);
            }
        }
        else if (string.IsNullOrEmpty(dataJsonPropertyName) || !root.TryGetProperty(dataJsonPropertyName, out _))
        {
            if (typeof(T) == typeof(string))
            {
                var text = root.GetRawText();
                response.Data = (T)(object)text;
            }
            else
            {
                response.Data = JsonSerializer.Deserialize<T>(root.GetRawText(), GloabalJsonOptions.OptionsForDeserialize);
            }
        }
    }

    private static void MapErrorToException(ApiResponse<T> response)
    {
        if (response.ErrorDetails is null) return;

        var apiException = new DynuApiException(response.ErrorDetails.StatusCode, response.ErrorDetails.Type, response.ErrorDetails.Message);

        if (apiException.Message.Contains("requires membership"))
        {
            response.Error = new NotAMemberException(new ApiError() { Message = "This operation requires membership. Please check your membership status and try again.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException);
            return;
        }

        response.Error = response.ErrorDetails.StatusCode switch
        {
            401 => new DynuAuthenticationException(new ApiError() { Message = "Authentication failed. Please check your credentials and try again.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException),
            404 => new ResourceNotFoundException(new ApiError() { Message = "The requested resource could not be found. Please check the resource identifier and try again.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException),
            500 => new ServerException(new ApiError() { Message = "A server error occurred. Please try again later.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException),
            502 => new ParseException(new ApiError() { Message = "There was an error when parsing the request and its parameters.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException),
            504 => new NotAMemberException(new ApiError() { Message = "This operation requires membership. Please check your membership status and try again.", Type = response.ErrorDetails.Type, StatusCode = response.ErrorDetails.StatusCode }, apiException),
            _ => apiException,
        };
    }
}