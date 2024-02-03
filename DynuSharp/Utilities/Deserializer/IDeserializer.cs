using System.Text.Json;

namespace DynuSharp.Utilities.Deserializer;
public interface IDeserializer<TBase>
{
    TBase? Deserialize(in JsonElement jsonElement);
    List<TBase> DeserializeArray(in JsonElement jsonElement);
    List<T> DeserializeArray<T>(in JsonElement jsonElement) where T : class, TBase;
    T? Deserialize<T>(in JsonElement jsonElement) where T : class, TBase;

}
