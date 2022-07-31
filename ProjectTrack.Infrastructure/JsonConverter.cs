using ProjectTrack.Application.Common;
using ProjectTrack.Domain.Common;

namespace ProjectTrack.Infrastructure;

public class JsonConverter : IJsonConverter
{
    public string ToString<T>(T model) 
        => System.Text.Json.JsonSerializer.Serialize(model);

    public T? FromString<T>(string json) 
        => System.Text.Json.JsonSerializer.Deserialize<T>(json);
}