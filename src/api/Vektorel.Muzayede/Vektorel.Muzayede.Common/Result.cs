namespace Vektorel.Muzayede.Common;

public class Result
{
    public Result(bool succeeded = true, string message = "Başarılı")
    {
        Succeeded = succeeded;
        Message = message;
    }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}


public class Result<T> : Result
{
    private Result(T data, bool succeeded, string message) : base(succeeded, message)
    {
        Data = data;
    }
    private Result(T data) : base()
    {
        Data = data;
    }
    public T Data { get; set; }

    public static Result<T> Fail(string message)
    {
        return new Result<T>(default(T), false, message);
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(data);
    }
}