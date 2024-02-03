using DynuSharp.Security.KeyVault;
using DynuSharp.Utilities;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace DynuSharp.Security;
public class SecureMemoryStorage : ISecureMemoryStorage
{
    private readonly string _instance;
    private readonly ConcurrentQueue<Action> _pendingActions = new();
    private readonly ManualResetEvent _migratedEvent = new ManualResetEvent(true);

    private IKeyVault? _keyVault;
    private IKeyVault? _temporaryKeyVault;

    private bool _disposed = false;
    private bool _isInitialized = false;

    public SecureMemoryStorage()
    {
        _instance = Guid.NewGuid().ToString("N").ToUpper();
        _temporaryKeyVault = new ObfuscationKeyVault();

        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();

        _temporaryKeyVault.Add($"{_instance}-key", aes.Key);
        _temporaryKeyVault.Add($"{_instance}-IV", aes.IV);

        Task.Run(Initialize);
    }

    public SecureMemoryStorage(IKeyVault keyVault)
    {
        _isInitialized = true;
        _instance = Guid.NewGuid().ToString("N").ToUpper();

        _keyVault = keyVault;

        using var aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();
        _keyVault.Add($"{_instance}-key", aes.Key);
        _keyVault.Add($"{_instance}-IV", aes.IV);
    }

    ~SecureMemoryStorage() => Dispose(false);

    public string Add<T>(T value)
    {
        _migratedEvent.WaitOne();

        if (!_isInitialized)
        {
            var key = GenerateRandomEnvVarName();
            _pendingActions.Enqueue(() => AddInternal(value, _keyVault!, key));
            return AddInternal(value, _temporaryKeyVault!, key);
        }
        else
        {
            return AddInternal(value, _keyVault!);
        }
    }

    public T Get<T>(string key)
    {
        _migratedEvent.WaitOne();

        if (!_isInitialized)
            return GetInternal<T>(_temporaryKeyVault!, key);
        else
            return GetInternal<T>(_keyVault!, key);
    }

    public void Remove(string key) => Environment.SetEnvironmentVariable(key, null, EnvironmentVariableTarget.Process);

    private void Initialize()
    {
        try
        {
            _keyVault = new TpmKeyVault();

            _keyVault.Add($"{_instance}-key", _temporaryKeyVault!.Get<byte[]>($"{_instance}-key"));
            _keyVault.Add($"{_instance}-IV", _temporaryKeyVault!.Get<byte[]>($"{_instance}-IV"));
        }
        catch
        {
            _keyVault = _temporaryKeyVault!;
        }


        if (_keyVault != _temporaryKeyVault)
        {
            _migratedEvent.Reset();
            MigrateDataFromTemporaryToMainVault();
            _migratedEvent.Set();

            _temporaryKeyVault!.Dispose();
            _temporaryKeyVault = null;
        }

        _isInitialized = true;
    }

    private void MigrateDataFromTemporaryToMainVault()
    {
        while (_pendingActions.TryDequeue(out var action))
            action();
    }

    private string AddInternal<T>(T value, IKeyVault keyVault, string? key = null)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        var stringValue = ConversionHelper.ToString(value);
        if (string.IsNullOrEmpty(stringValue)) throw new ArgumentException("Value cannot be empty", nameof(value));

        key ??= GenerateRandomEnvVarName();
        var encryptedBase64 = EncryptStringToBase64(keyVault, ref stringValue);
        Environment.SetEnvironmentVariable(key, encryptedBase64, EnvironmentVariableTarget.Process);

        return key;
    }

    private T GetInternal<T>(IKeyVault keyVault, string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentException("Key cannot be empty", nameof(key));

        var stringValue = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        if (string.IsNullOrEmpty(stringValue)) throw new ArgumentNullException(nameof(stringValue));

        var decryptedString = DecryptStringFromBase64(keyVault, ref stringValue);
        if (string.IsNullOrEmpty(decryptedString)) throw new NullReferenceException(nameof(decryptedString));

        return ConversionHelper.FromString<T>(decryptedString);
    }

    private string EncryptStringToBase64(IKeyVault keyVault, ref string plainText)
    {
        var key = keyVault.Get<byte[]>($"{_instance}-key");
        var iv = keyVault.Get<byte[]>($"{_instance}-IV");

        using var msEncrypt = new MemoryStream();
        using var aes = Aes.Create();
        using var csEncrypt = new CryptoStream(msEncrypt, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);

        swEncrypt.Write(plainText);
        swEncrypt.Flush();
        csEncrypt.FlushFinalBlock();

        msEncrypt.Position = 0;
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    private string? DecryptStringFromBase64(IKeyVault keyVault, ref string base64)
    {
        var key = keyVault.Get<byte[]>($"{_instance}-key");
        var iv = keyVault.Get<byte[]>($"{_instance}-IV");

        using var msDecrypt = new MemoryStream(Convert.FromBase64String(base64));
        using var aes = Aes.Create();
        using var csDecrypt = new CryptoStream(msDecrypt, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }

    private string GenerateRandomEnvVarName() => $"ENV_{_instance}{Guid.NewGuid().ToString("N").ToUpper()}";

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
        {
            var environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            foreach (string key in environmentVariables.Keys)
            {
                if (key.StartsWith($"ENV_{_instance}"))
                    Remove(key);
            }

            _keyVault?.Dispose();
            _temporaryKeyVault?.Dispose();
        }

        _disposed = true;
    }
}
