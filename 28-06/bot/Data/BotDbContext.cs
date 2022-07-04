using System.Reflection;
using bot.Entity;
using Microsoft.EntityFrameworkCore;

namespace bot.Data;

public class BotDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public BotDbContext(DbContextOptions<BotDbContext> options)
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}