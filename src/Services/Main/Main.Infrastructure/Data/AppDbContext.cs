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

        builder.Entity<Order>()
            .HasMany(p => p.Products)
            .WithMany();

        builder.Entity<Cart>()
            .HasMany(p => p.Products)
            .WithMany();

        builder.Entity<Cart>()
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Cart>(p => p.Id);

        builder.Entity<Invoice>()
            .HasOne(e => e.Order)
            .WithOne();
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Courier> Couriers { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
}