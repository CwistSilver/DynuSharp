using DynuSharp.Data.Dns;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynuSharp.Utilities.Json;
public static class GloabalJsonOptions
{
    public static JsonSerializerOptions? _optionsForDeserialize;
    public static JsonSerializerOptions OptionsForDeserialize
    {
        get
        {
            if (_optionsForDeserialize is null)
                Init();

            return _optionsForDeserialize;
        }
    }

    public static JsonSerializerOptions? _options;
    public static JsonSerializerOptions Options
    {
        get
        {
            if (_options is null)
                Init();

            return _options;
        }
    }
    private static void Init()
    {
        _optionsForDeserialize = new JsonSerializerOptions();
        //_optionsForDeserialize.Converters.Add(new DomainStateJsonConverter());
        _optionsForDeserialize.Converters.Add(new JsonStringEnumConverter());

        _options = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
        //_options.Converters.Add(new DomainStateJsonConverter());
        _options.Converters.Add(new JsonStringEnumConverter());

        var assembly = Assembly.GetAssembly(typeof(DnsDomain));

        foreach (var type in assembly.GetTypes())
        {
            bool hasIgnoreOnPostAttribute = type.GetProperties().Any(prop => Attribute.IsDefined(prop, typeof(IgnoreOnPostAttribute)));
            if (hasIgnoreOnPostAttribute)
            {
                Type converterType = typeof(IgnoreOnPostConverter<>).MakeGenericType(type);
                _options.Converters.Add((JsonConverter)Activator.CreateInstance(converterType));
            }
        }
    }
}
