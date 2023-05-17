using Main.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().OwnsOne(u => u.Cart).OwnsMany(c => c.Products);
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
}