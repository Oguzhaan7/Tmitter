namespace Tmitter.Application.Users.Common;

public class UserResponse
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string ProfilePicture { get; set; } = null!;
    public string Bio { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string Token { get; set; } = null!;
}