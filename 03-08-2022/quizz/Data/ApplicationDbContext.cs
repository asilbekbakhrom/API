using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using quizz.Entities;

namespace quizz.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Topic>? Topics { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        AddNameHash();
        SetDates();
        
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddNameHash();
        SetDates();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetDates()
    {
        foreach(var entry in ChangeTracker.Entries<EntityBase>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }

            if(entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }
    }

    private void AddNameHash()
    {
        foreach(var entry in ChangeTracker.Entries<Topic>())
        {
            if(entry.Entity is Topic topic)
            {
                using var sha256 = SHA256.Create();
                var nameBytes = Encoding.UTF8.GetBytes(topic.Name 
                    ?? throw new ArgumentNullException(nameof(topic.Name)));
                var hashBytes = sha256.ComputeHash(nameBytes);

                topic.NameHash = Encoding.UTF8.GetString(hashBytes);
            }
        }
    }
}