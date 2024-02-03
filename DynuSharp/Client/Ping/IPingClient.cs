namespace DynuSharp.Client.Ping;
public interface IPingClient
{
    /// <summary>
    /// Sends a ping request to the API server using a query parameter to convey the message and receives a pong response.
    /// </summary>
    /// <param name="message">The message to receive back in pong.</param>
    /// <returns>The response to ping operation.</returns>
    Task<string> PingWithQueryAsync(string message);

    /// <summary>
    /// Sends a ping request to the API server using the request body to convey the message and receives a pong response.
    /// </summary>
    /// <param name="message">The message to receive back in pong.</param>
    /// <returns>The response to ping operation.</returns>
    Task<string> PingWithBodyAsync(string message);
}
