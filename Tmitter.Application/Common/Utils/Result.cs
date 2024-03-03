namespace Tmitter.Application.Common.Utils;

public class Result
{
    public Result()
    {
    }

    public Result(int code, bool succeeded, string? message)
    {
        Code = code;
        Succeeded = succeeded;
        Message = message;
    }

    public string? Message { get; set; } = string.Empty;
    public int Code { get; set; }
    public bool Succeeded { get; set; }

    public static Result Success(int code, string? message)
    {
        return new Result
        {
            Succeeded = true,
            Code = code,
            Message = message
        };
    }

    public static Result Failure(int code, string? message)
    {
        return new Result
        {
            Succeeded = false,
            Code = code,
            Message = message
        };
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public static Result<T> Success(T data, int code, string? message)
    {
        return new Result<T>
        {
            Data = data,
            Succeeded = true,
            Code = code,
            Message = message
        };
    }

    public static Result<T> Failure(T data, int code, string? message)
    {
        return new Result<T>
        {
            Data = data,
            Succeeded = true,
            Code = code,
            Message = message
        };
    }
}