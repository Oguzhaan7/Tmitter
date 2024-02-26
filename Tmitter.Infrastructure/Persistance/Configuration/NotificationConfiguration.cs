using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("notifications");

        builder.HasKey(notification => notification.Id);
        builder.Property(notification => notification.Id)
            .ValueGeneratedOnAdd();

        builder.Property(notification => notification.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(notification => notification.Content)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(notification => notification.IsReaded)
            .IsRequired();

        builder.Property(notification => notification.CreatedAt)
            .IsRequired();
    }
}