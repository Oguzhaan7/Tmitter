namespace Tmitter.Domain;

public class Like : BaseEntity
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Post Post { get; set; } = new();
    public User User { get; set; } = new();
}