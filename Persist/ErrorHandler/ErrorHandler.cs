using System.Diagnostics;

namespace ErrorHandler;
public class ErrorObjectHandler<T>
{
    public bool Success { get; set; }
    public required T Data { get; set; }
    public required string ErrorMessage { get; set; }
    public StackTrace? StackTrace { get; set; }
}
