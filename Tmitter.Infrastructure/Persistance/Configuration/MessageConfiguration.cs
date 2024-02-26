using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Configuration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");

        builder.HasKey(message => message.Id);
        builder.Property(message => message.Id)
            .ValueGeneratedOnAdd();

        builder.Property(message => message.Text)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(message => message.IsReaded)
            .IsRequired();

        builder.Property(message => message.SentAt)
            .IsRequired();
    }
}