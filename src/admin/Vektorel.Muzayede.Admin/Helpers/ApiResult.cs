namespace Vektorel.Muzayede.Admin.Helpers;

public class ApiResult<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}