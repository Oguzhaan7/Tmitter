using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts");

        builder.HasKey(post => post.Id);
        builder.Property(post => post.Id)
            .ValueGeneratedOnAdd();

        builder.Property(post => post.Text)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(post => post.Image)
            .HasMaxLength(255);

        builder.Property(post => post.CreatedAt)
            .IsRequired();

        builder.Property(post => post.UpdatedAt)
            .IsRequired();
    }
}