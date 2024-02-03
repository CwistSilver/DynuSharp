namespace DynuSharp.Security;

/// <summary>
/// A storage where critical variables can be safely stored in memory.
/// <para>
/// Note: The values are only stored as long as this process is running. Once the process is closed, the information is gone.
/// </para>
/// </summary>
public interface ISecureMemoryStorage : IDisposable
{
    /// <summary>
    /// It adds a value to the storage.
    /// </summary>
    /// <param name="value">The <typeparam name="T"></typeparam> value to be added to the storage</param>
    /// <returns>the key with which you can get the value back with the <see cref="Get"/> method</returns>
    string Add<T>(T value);

    /// <summary>
    /// It removes a value from the storage.
    /// </summary>
    /// <param name="key">The key under which a value is stored</param>
    /// <returns>the key with which you can get the value back with the <see cref="Get"/> method</returns>
    void Remove(string key);

    /// <summary>
    /// Get the value to a specific key
    /// </summary>
    /// <param name="key">The key under which a value is stored</param>
    /// <returns> The value of  <typeparamref name="T"/> stored with the key.</returns>
    T Get<T>(string key);
}