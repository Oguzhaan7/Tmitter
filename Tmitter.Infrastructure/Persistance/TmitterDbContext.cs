using Microsoft.EntityFrameworkCore;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance;

public class TmitterDbContext : DbContext
{
    public TmitterDbContext()
    {
    }

    public TmitterDbContext(DbContextOptions<TmitterDbContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TmitterDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}