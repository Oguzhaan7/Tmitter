using Tmitter.Domain;

namespace Tmitter.Application.Common.Authentication;

public interface IAuthentication
{
    string GenerateToken(User user);
    bool ValidateToken(string token);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}