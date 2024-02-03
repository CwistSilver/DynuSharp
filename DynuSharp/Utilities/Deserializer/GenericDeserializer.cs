using DynuSharp.Utilities.Json;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;

namespace DynuSharp.Utilities.Deserializer;
public sealed class GenericDeserializer<TBase, TEnum> : IDeserializer<TBase>
    where TBase : class
    where TEnum : struct, Enum
{
    private readonly string _propertyKey;
    private readonly string _jsonKey;
    private readonly ConcurrentDictionary<TEnum, Type> _typeDictionary = new();

    public GenericDeserializer(string propertyKey, string jsonKey)
    {
        _propertyKey = propertyKey;
        _jsonKey = jsonKey;

        var types = Assembly.GetAssembly(typeof(TBase))!.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(TBase)));

        foreach (var type in types)
        {
            var instance = (TBase)Activator.CreateInstance(type)!;
            var typeValue = (TEnum)type.GetProperty(_propertyKey)!.GetValue(instance)!;
            _typeDictionary.TryAdd(typeValue, type);
        }
    }

    public TBase? Deserialize(in JsonElement jsonElement)
    {
        if (!jsonElement.TryGetProperty(_jsonKey, out JsonElement typeElement))
            throw new InvalidOperationException($"Property '{_propertyKey}' could not be found in the JsonElement");

        var typeKey = Enum.Parse<TEnum>(typeElement.GetString()!);

        if (_typeDictionary.TryGetValue(typeKey, out var targetType))
            return jsonElement.Deserialize(targetType, GloabalJsonOptions.OptionsForDeserialize) as TBase;
        else
            throw new InvalidOperationException($"Unknown type '{typeKey}'.");
    }

    public List<TBase> DeserializeArray(in JsonElement jsonElement)
    {
        if (jsonElement.ValueKind != JsonValueKind.Array)
            throw new JsonException("Unexpected JSON format. An array was expected.");

        var results = new List<TBase>();
        foreach (JsonElement element in jsonElement.EnumerateArray())
        {
            var result = Deserialize(element);
            if (result is not null)
                results.Add(result);
        }

        return results;
    }

    public List<T> DeserializeArray<T>(in JsonElement jsonElement) where T : class, TBase
    {
        if (jsonElement.ValueKind != JsonValueKind.Array)
            throw new JsonException("Unexpected JSON format. An array was expected.");

        var results = new List<T>();
        foreach (JsonElement element in jsonElement.EnumerateArray())
        {
            var result = element.Deserialize(typeof(T), GloabalJsonOptions.OptionsForDeserialize) as T;
            if (result is not null)
                results.Add(result);
        }

        return results;
    }

    public T? Deserialize<T>(in JsonElement jsonElement) where T : class, TBase => jsonElement.Deserialize(typeof(T), GloabalJsonOptions.OptionsForDeserialize) as T;
}
