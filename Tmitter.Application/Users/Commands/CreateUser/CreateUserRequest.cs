namespace Tmitter.Application.Users.Commands.CreateUser;

public record CreateUserRequest(string Username, string Email, string Password, string FullName, DateTime BirthDate);