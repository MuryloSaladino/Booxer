using Booxer.Domain.Enums;

namespace Booxer.Domain.Common;

public class BaseException(string message, ExceptionCode exceptionCode, string? details = null) 
    : Exception(message)
{
    public ExceptionCode ExceptionCode { get; set; } = exceptionCode;
    public string? Details = details;
}
