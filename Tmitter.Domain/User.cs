namespace Tmitter.Domain;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string ProfilePicture { get; set; } = null!;
    public string Bio { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<User> Following { get; } = new List<User>();
    public ICollection<User> Followers { get; } = new List<User>();
    public ICollection<Post> Posts { get; } = new List<Post>();
}