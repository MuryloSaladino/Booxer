using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.Application.Exceptions;

public class AuthenticationException(string message)
    : BaseException("Unauthorized: " + message, ExceptionCode.Unauthorized);
    
public class NotAdminException()
    : BaseException("Forbidden access: you need admin privileges.", ExceptionCode.Forbidden);
