namespace Tmitter.Domain;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public string Type { get; set; } = null!;
    public string Content { get; set; } = null!;
    public bool IsReaded { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = new();
}