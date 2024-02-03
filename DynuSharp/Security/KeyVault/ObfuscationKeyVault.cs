using DynuSharp.Utilities;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;

namespace DynuSharp.Security.KeyVault;
public sealed class ObfuscationKeyVault : IKeyVault
{
    private readonly ConcurrentDictionary<string, string> _obfuscationDictionary = new();
    private readonly string _secureKey;
    private bool _disposed = false;

    public ObfuscationKeyVault() => _secureKey = Guid.NewGuid().ToString();
    ~ObfuscationKeyVault() => Dispose(false);

    private string Decrypt(ref string base64)
    {
        var process = Process.GetCurrentProcess();
        var keys = Encoding.UTF8.GetBytes($"{process.Id}-{_secureKey}-{process.StartTime}");
        var data = Convert.FromBase64String(base64);

        for (int i = 0; i < keys.Length; i++)
        {
            for (int x = 0; x < data.Length; x++)
            {
                data[x] = (byte)(data[x] ^ keys[i]);
            }
        }

        return Encoding.UTF8.GetString(data);
    }

    private string Encrypt(ref string value)
    {
        var process = Process.GetCurrentProcess();
        var keys = Encoding.UTF8.GetBytes($"{process.Id}-{_secureKey}-{process.StartTime}");
        var data = Encoding.UTF8.GetBytes(value);

        for (int i = 0; i < keys.Length; i++)
        {
            for (int x = 0; x < data.Length; x++)
            {
                data[x] = (byte)(data[x] ^ keys[i]);
            }
        }

        return Convert.ToBase64String(data);
    }

    public void Add<T>(string key, T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        var stringValue = ConversionHelper.ToString(value);
        if (string.IsNullOrEmpty(stringValue)) throw new ArgumentException("Value cannot be empty", nameof(value));
        var encryptBase64Value = Encrypt(ref stringValue);

        _obfuscationDictionary.AddOrUpdate(key, encryptBase64Value, (k, oldValue) =>
        {
            return encryptBase64Value;
        });
    }

    public T Get<T>(string key)
    {
        if (!_obfuscationDictionary.TryGetValue(key, out var encryptBase64Value))
            throw new KeyNotFoundException($"No key found for: {key} in _obfuscationDictionary");

        var decryptedString = Decrypt(ref encryptBase64Value);

        return ConversionHelper.FromString<T>(decryptedString);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
            _obfuscationDictionary.Clear();

        _disposed = true;
    }
}