namespace OrderService.Domain.Common;

public record Error
{
    public string Message { get; }
    public string Code { get; }

    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }
}