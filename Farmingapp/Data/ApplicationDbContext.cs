// AgriEnergyContext.cs
using Microsoft.EntityFrameworkCore;

public class AgriEnergyContext : DbContext
{
    public AgriEnergyContext(DbContextOptions<AgriEnergyContext> options) : base(options)
    {
    }

    public DbSet<Farmer> Farmers { get; set; }
    public DbSet<Product> Products { get; set; }
}