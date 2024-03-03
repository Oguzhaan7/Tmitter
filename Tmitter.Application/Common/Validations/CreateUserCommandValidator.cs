using FluentValidation;
using Tmitter.Application.Users.Commands.CreateUser;

namespace Tmitter.Application.Common.Validations;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Email)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Email is required");

        RuleFor(user => user.Username)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Username is required");

        RuleFor(user => user.FullName)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("FullName is required");

        RuleFor(user => user.Password)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Password is required")
            .Length(6, 25)
            .WithMessage("Password should be 6 characters at least");
    }
}