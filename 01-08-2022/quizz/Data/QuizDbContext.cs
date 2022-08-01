using System.Reflection;
using Microsoft.EntityFrameworkCore;
using quizz.Entities;

namespace quizz.Data;

public class QuizDbContext : DbContext
{
    public DbSet<Quiz> Quizes { get; set; }

    public QuizDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}