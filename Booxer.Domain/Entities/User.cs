using Booxer.Domain.Common;

namespace Booxer.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public bool IsAdmin { get; set; } = false;
}
