using MarketAPI.UnidadeTerra.CS.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.UnidadeTerra.CS.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<Market> Markets { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Market>()
            .HasMany(m => m.Sales)
            .WithOne(s => s.Market)
            .HasForeignKey(s => s.MarketId);

        builder.Entity<Sale>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Sale)
            .HasForeignKey(p => p.SaleId);
    }
}