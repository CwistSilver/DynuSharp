namespace DynuSharp.Utilities;
internal static class ConversionHelper
{
    internal static string? ToString<T>(T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));

        var type = value.GetType();
        if (type == typeof(string))
            return (value as string)!;

        if (type == typeof(byte[]))
            return Convert.ToBase64String((value as byte[])!);

        return value.ToString();
    }

    internal static T FromString<T>(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

        if (typeof(T) == typeof(string))
            return (T)(object)value;

        if (typeof(T) == typeof(byte[]))
            return (T)(object)Convert.FromBase64String(value);

        try
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Cannot convert {value} to type {typeof(T).Name}", ex);
        }
    }
}
