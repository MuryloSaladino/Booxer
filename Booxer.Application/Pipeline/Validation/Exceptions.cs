using System.Text.Json;
using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.Application.Pipeline.Validation;

public class RequestValidationException(Dictionary<string, string> errors)
    : BaseException("One or more validation errors occurred.", ExceptionCode.BadRequest)
{
    public Dictionary<string, string> Errors { get; } = errors;

    public override string ToMessage()
        => JsonSerializer.Serialize(new
        {
            message = Message,
            code = ExceptionCode,
            details = Errors,
        });
}
