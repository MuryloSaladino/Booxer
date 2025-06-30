using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.Application.Exceptions;

public class RequestValidationException(string details)
    : BaseException("One or more validation errors occurred.", ExceptionCode.BadRequest, details);
