using FluentValidation;

namespace Booxer.Application.Commands.Auth.Login;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(l => l.UsernameOrEmail)
            .NotEmpty();

        RuleFor(l => l.Password)
            .NotEmpty();
    }
}