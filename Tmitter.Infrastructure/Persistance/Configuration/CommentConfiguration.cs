using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(comment => comment.Id);
        builder.Property(comment => comment.Id)
            .ValueGeneratedOnAdd();

        builder.Property(comment => comment.Text)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(comment => comment.CreatedAt)
            .IsRequired();
    }
}