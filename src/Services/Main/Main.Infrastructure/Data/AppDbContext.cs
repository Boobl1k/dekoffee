using Main.Application.Models;
using Main.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        foreach (var entity in builder.Model.GetEntityTypes())
        foreach (var property in entity.GetProperties().Where(p => p.IsPrimaryKey()))
            property.ValueGenerated = ValueGenerated.Never;

        builder.Entity<Address>().HasKey(a => a.Id);
        
        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().OwnsOne(o => o.Invoice);
        builder.Entity<Order>().OwnsMany(o => o.Products);

        builder.Entity<Product>().HasKey(p => p.Id);
        
        builder.Entity<User>().OwnsOne(u => u.Cart).OwnsMany(c => c.Products);

        builder.AddSeedProducts();
        builder.AddSeedAddresses();
        builder.AddSeedUsers();
        builder.AddSeedOrders();
        builder.AddSeedRoles();
        builder.AddSeedUserRoles();
    }

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
}