namespace Tmitter.Domain;

public class Post : BaseEntity
{
    public string Text { get; set; } = null!;
    public string Image { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = new();
    public ICollection<Like> Likes { get; } = new List<Like>();
    public ICollection<Comment> Comments { get; } = new List<Comment>();
}