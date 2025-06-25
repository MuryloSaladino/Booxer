using Booxer.Domain.Common;
using Booxer.Domain.Enums;

namespace Booxer.Infrastructure.Identity;

public class InvalidSessionException() 
    : BaseException("Invalid session, login needed.", ExceptionCode.Unauthorized);