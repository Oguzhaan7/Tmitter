using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("likes");

        builder.HasKey(like => like.Id);
        builder.Property(like => like.Id)
            .ValueGeneratedOnAdd();

        builder.Property(like => like.CreatedAt)
            .IsRequired();
    }
}