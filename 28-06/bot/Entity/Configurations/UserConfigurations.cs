using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bot.Entity.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.AccountId).IsUnique();
        builder.HasIndex(u => u.ChatId).IsUnique();
        builder.Property(u => u.Firstname).HasMaxLength(16);
        builder.Property(u => u.Lastname).HasMaxLength(16);
        builder.Property(u => u.Phone).HasMaxLength(15);
    }
}