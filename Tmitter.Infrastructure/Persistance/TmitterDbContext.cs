using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance;

public partial class TmitterDbContext : DbContext
{
    public TmitterDbContext()
    {
    }

    public TmitterDbContext(DbContextOptions<TmitterDbContext> contextOptions) : base(contextOptions)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Hashtag> Hashtags { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TmitterDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}