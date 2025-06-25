using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.Domain.Exceptions;

public class InternalException() 
    : BaseException("Internal server error.", ExceptionCode.InternalServerError);