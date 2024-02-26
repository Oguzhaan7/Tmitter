namespace Tmitter.Domain;

public class Message : BaseEntity
{
    public Guid SenderId { get; set; }
    public Guid ReceiverId { get; set; }
    public string Text { get; set; } = null!;
    public bool IsReaded { get; set; }
    public DateTime SentAt { get; set; }

    public User SenderUser { get; set; } = new();
    public User ReceiverUser { get; set; } = new();
}