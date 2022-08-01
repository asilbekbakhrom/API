using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace quizz.Entities.Configurations;

public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(b => b.UpdatedAt).ValueGeneratedOnAddOrUpdate();
    }
}