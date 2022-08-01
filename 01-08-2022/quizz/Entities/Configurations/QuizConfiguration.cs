using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace quizz.Entities.Configurations;

public class QuizConfiguration : EntityBaseConfiguration<Quiz>
{
    public override void Configure(EntityTypeBuilder<Quiz> builder)
    {
        base.Configure(builder);
        
        builder.Property(b => b.Name).HasColumnType("nvarchar(255)").IsRequired();
        builder.Property(b => b.Description).HasColumnType("nvarchar(1024)");
        builder.Property(b => b.Categories).HasColumnType("nvarchar(255)").IsRequired();
        builder.Property(b => b.StartTime).IsRequired();
        builder.Property(b => b.EndTime).IsRequired();
    }
}