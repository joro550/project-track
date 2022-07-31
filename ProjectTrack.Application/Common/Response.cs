namespace ProjectTrack.Application.Common;

public class Response<T>
{
    public bool Success { get; set; }
    public T Result { get; set; }

    public static implicit operator Response<T>(T model) =>
        new()
        {
            Success = true,
            Result = model
        };

    public static Response<T> Failure() => new() { Success = false };
}