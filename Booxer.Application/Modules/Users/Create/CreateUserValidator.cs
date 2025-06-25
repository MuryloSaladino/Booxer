using Booxer.Domain.Repository.Users;
using FluentValidation;

namespace Booxer.Application.Modules.Users.Create;

public class RegisterUserValidator : AbstractValidator<CreateUserRequest>
{
    public RegisterUserValidator(IUsersRepository usersRepository)
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(35)
            .MustAsync(async (username, cancellationToken) => !await usersRepository
                .Exists(new() { UsernameOrEmail = username }, cancellationToken));

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .MustAsync(async (email, cancellationToken) => !await usersRepository
                .Exists(new() { UsernameOrEmail = email }, cancellationToken));

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}