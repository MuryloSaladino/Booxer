using FluentValidation;

namespace Booxer.Application.Modules.Users.Create;

public class RegisterUserValidator : AbstractValidator<CreateUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(35);

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}