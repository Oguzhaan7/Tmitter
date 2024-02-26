namespace Tmitter.Domain;

public class Comment : BaseEntity
{
    public string Text { get; set; } = null!;
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Post Post { get; set; } = new();
    public User User { get; set; } = new();
}