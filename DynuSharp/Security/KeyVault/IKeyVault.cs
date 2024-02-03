namespace DynuSharp.Security.KeyVault;

public interface IKeyVault : IDisposable
{
    void Add<T>(string key, T value);
    T Get<T>(string key);
}