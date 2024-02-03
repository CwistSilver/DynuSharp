using DynuSharp.Utilities;
using System.Collections.Concurrent;
using System.Text;
using Tpm2Lib;

namespace DynuSharp.Security.KeyVault;
public sealed class TpmKeyVault : IKeyVault
{
    private const ushort KeyBits = 2048;
    private const ushort Exponent = 0;

    private bool _disposed = false;

    private readonly Tpm2 _tpm;
    private readonly ConcurrentDictionary<string, TpmHandle> _handleMap = new();
    private readonly ConcurrentDictionary<string, byte[]> _messageeMap = new();
    private readonly TpmHandle _primaryHandle;

    public TpmKeyVault()
    {
        Tpm2Device tpmDevice;
        if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            tpmDevice = new TbsDevice();
        else
            tpmDevice = new LinuxTpmDevice();

        tpmDevice.Connect();
        _tpm = new Tpm2(tpmDevice);
        _primaryHandle = CreateRsaPrimaryKey(_tpm);
    }

    ~TpmKeyVault() => Dispose(false);

    public void PrintVersion()
    {
        var tpmVersion = _tpm.GetFirmwareVersionEx();

        if (tpmVersion.Length >= 3)
        {
            uint firmwareVersion1 = tpmVersion[0];
            uint firmwareVersion2 = tpmVersion[1];
            uint revision = tpmVersion[2];

            Console.WriteLine($"Firmware Version 1: {firmwareVersion1}");
            Console.WriteLine($"Firmware Version 2: {firmwareVersion2}");
            Console.WriteLine($"Revision: {revision}");
        }
        else
        {
            Console.WriteLine("Failed to retrieve TPM firmware version information.");
        }
    }

    public void Add<T>(string key, T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        var stringValue = ConversionHelper.ToString(value);
        if (string.IsNullOrEmpty(stringValue)) throw new ArgumentException("Value cannot be empty", nameof(value));

        var keyHandle = CreateSigningDecryptionKey(_tpm, _primaryHandle, out var keyPublic);
        _handleMap[key] = keyHandle;

        var valueBytes = Encoding.UTF8.GetBytes(stringValue);
        var encryptedData = _tpm.RsaEncrypt(keyHandle, valueBytes, new SchemeOaep(TpmAlgId.Sha1), null);

        _messageeMap.AddOrUpdate(key, encryptedData, (k, oldValue) =>
        {
            return encryptedData;
        });
    }

    public T Get<T>(string key)
    {
        if (!_handleMap.TryGetValue(key, out var keyHandle))
            throw new KeyNotFoundException($"No key found for: {key} in _handleMap");


        if (!_messageeMap.TryGetValue(key, out var encryptedData))
            throw new KeyNotFoundException($"No key found for: {key} in _messageeMap");

        byte[] decryptedData;
        try
        {
            decryptedData = _tpm.RsaDecrypt(keyHandle, encryptedData!, new SchemeOaep(TpmAlgId.Sha1), null);
        }
        catch (TpmException ex)
        {
            throw new InvalidOperationException("Failed to decrypt data", ex);
        }

        var decryptedString = Encoding.UTF8.GetString(decryptedData);
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
        {
            _tpm.Dispose();
            _handleMap.Clear();
            _messageeMap.Clear();
        }

        _disposed = true;
    }

    private static TpmHandle CreateSigningDecryptionKey(Tpm2 tpm, TpmHandle primHandle, out TpmPublic keyPublic)
    {
        var keyInPublic = new TpmPublic(
            TpmAlgId.Sha1,
            ObjectAttr.Decrypt | ObjectAttr.Sign | ObjectAttr.FixedParent | ObjectAttr.FixedTPM | ObjectAttr.UserWithAuth | ObjectAttr.SensitiveDataOrigin,
            null,
            new RsaParms(new SymDefObject(), new NullAsymScheme(), KeyBits, Exponent), new Tpm2bPublicKeyRsa());

        var sensCreate = new SensitiveCreate(new byte[] { 1, 2, 3 }, null);
        var keyPrivate = tpm.Create(primHandle,
                                           sensCreate,
                                           keyInPublic,
                                           null,
                                           Array.Empty<PcrSelection>(),
                                           out keyPublic,
                                           out _,
                                           out _,
                                           out _);

        tpm._Behavior.Strict = true;
        tpm._ExpectError(TpmRc.AuthMissing).Load(primHandle, keyPrivate, keyPublic);

        var keyHandle = tpm[Auth.Default].Load(primHandle, keyPrivate, keyPublic);
        tpm._Behavior.Strict = false;

        return keyHandle;
    }
    private static TpmHandle CreateRsaPrimaryKey(Tpm2 tpm)
    {
        var sensCreate = new SensitiveCreate(new byte[] { 0xa, 0xb, 0xc }, null);
        var parms = new TpmPublic(
                  TpmAlgId.Sha1,
                  ObjectAttr.Restricted | ObjectAttr.Decrypt | ObjectAttr.FixedParent | ObjectAttr.FixedTPM | ObjectAttr.UserWithAuth | ObjectAttr.SensitiveDataOrigin,
                  null,
                  new RsaParms(new SymDefObject(TpmAlgId.Aes, 128, TpmAlgId.Cfb), new NullAsymScheme(), KeyBits, Exponent), new Tpm2bPublicKeyRsa());

        var outsideInfo = Globs.GetRandomBytes(8);
        var creationPcr = new PcrSelection(TpmAlgId.Sha1, new uint[] { 0, 1, 2 });
        var handler = tpm.CreatePrimary(TpmRh.Owner, sensCreate, parms, outsideInfo, new PcrSelection[] { creationPcr }, out _, out _, out _, out _);
        return handler;
    }
}