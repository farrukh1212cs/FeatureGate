using FeatureGate.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureGate.Api.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Feature> Features { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Feature>().HasData(
            new Feature { Id = 1, Name = "UserView", IsEnabled = true, Description = "Enable viewing users" },
            new Feature { Id = 2, Name = "UserCreate", IsEnabled = false, Description = "Enable creating users" },
            new Feature { Id = 3, Name = "UserUpdate", IsEnabled = true, Description = "Enable updating users" },
            new Feature { Id = 4, Name = "UserDelete", IsEnabled = false, Description = "Enable deleting users" }
        );
    }
}
