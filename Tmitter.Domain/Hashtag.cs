namespace Tmitter.Domain;

public class Hashtag : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<Post> Posts { get; } = new List<Post>();
}