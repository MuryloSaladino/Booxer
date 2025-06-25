using Microsoft.AspNetCore.Identity;
using Booxer.Domain.Identity;

namespace Booxer.Infrastructure.Identity.Services;

public class PasswordEncrypter : IPasswordEncrypter
{
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public bool Matches(string hash, string password)
    {
        var result = _hasher.VerifyHashedPassword(null!, hash, password);
        return result == PasswordVerificationResult.Success;
    }
}
