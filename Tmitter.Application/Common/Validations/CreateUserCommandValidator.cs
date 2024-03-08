using FluentValidation;
using Tmitter.Application.Users.Commands.CreateUser;

namespace Tmitter.Application.Common.Validations;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.UserRequest.Email)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Email is required");

        RuleFor(user => user.UserRequest.Username)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Username is required");

        RuleFor(user => user.UserRequest.FullName)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("FullName is required");

        RuleFor(user => user.UserRequest.Password)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Password is required")
            .Length(6, 25)
            .WithMessage("Password should be 6 characters at least");

        RuleFor(user => user.UserRequest.BirthDate.Year)
            .GreaterThanOrEqualTo(1950)
            .LessThanOrEqualTo(DateTime.Now.AddYears(-10).Year)
            .WithMessage(
                $"Birthdate should be between 01.01.1950 - {DateTime.Now.AddYears(-10).Day}.{DateTime.Now.AddYears(-10).Month}.{DateTime.Now.AddYears(-10).Year}");
    }
}