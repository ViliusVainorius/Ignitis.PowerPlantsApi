using Ignitis.PowerPlantsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.PowerPlantsApi.Data;

public class IgnitisDbContext : DbContext
{
    public IgnitisDbContext(DbContextOptions<IgnitisDbContext> options)
        : base(options)
    {
    }

    public DbSet<PowerPlant> PowerPlants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
