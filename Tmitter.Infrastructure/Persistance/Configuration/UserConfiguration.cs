using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id)
            .ValueGeneratedOnAdd();

        builder.Property(user => user.Username)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.Password)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(user => user.FullName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.BirthDate)
            .IsRequired();

        builder.Property(user => user.ProfilePicture)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(user => user.Bio)
            .HasMaxLength(250);

        builder.Property(user => user.Website)
            .HasMaxLength(250);

        builder.Property(user => user.CreatedAt)
            .IsRequired();

        builder.Property(user => user.UpdatedAt)
            .IsRequired();
    }
}