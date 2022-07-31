namespace ProjectTrack.Application.Common;

public interface IJsonConverter
{
    public string ToString<T>(T model);
    public T? FromString<T>(string json);
}