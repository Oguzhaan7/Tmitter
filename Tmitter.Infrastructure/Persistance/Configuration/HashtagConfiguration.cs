using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
{
    public void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        builder.ToTable("hashtags");

        builder.HasKey(hashtag => hashtag.Id);
        builder.Property(hashtag => hashtag.Id)
            .ValueGeneratedOnAdd();

        builder.Property(hashtag => hashtag.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}