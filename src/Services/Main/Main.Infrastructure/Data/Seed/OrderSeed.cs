using Main.Application.Models;
using Main.Tools;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class OrderSeed
{
    private const string KremlevskayaId = "F1BC39F8-0434-4C23-AB66-0DB72AC81B14";
    private const string DamirId = "6B75F65B-52C5-402F-A446-A6C8EF14AF80";
    private const string DekoId = "964D25DF-C2AC-4511-B43F-6588394AFD52";

    public static void AddSeedOrders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData(GetSeedOrders());
        modelBuilder.Entity<Order>().OwnsOne(o => o.Invoice).HasData(GetSeedInvoices());
        modelBuilder.Entity<Order>().OwnsMany(o => o.Products).HasData(GetSeedOrderProducts());
    }

    private static IEnumerable<object> GetSeedOrders()
    {
        yield return new
        {
            Id = KremlevskayaId.ToGuid(),
            TotalSum = 8600m,
            Status = OrderStatus.Accepted,
            DeadlineTime = new DateTime(2024, 05, 16, 16, 0, 0),
            LastUpdateTime = new DateTime(2023, 05, 12, 13, 0, 0),
            LowerSelectedTime = new DateTime(2023, 05, 12, 12, 0, 0),
            UpperSelectedTime = new DateTime(2024, 05, 16, 16, 0, 0),
            AddressId = AddressSeed.KremlevskayaId.ToGuid(),
            UserId = UserSeed.MansurId.ToGuid(),
        };
        yield return new
        {
            Id = DamirId.ToGuid(),
            TotalSum = 10m,
            Status = OrderStatus.Canceled,
            DeadlineTime = new DateTime(2023, 05, 16, 16, 0, 0),
            LastUpdateTime = new DateTime(2023, 05, 12, 13, 10, 2),
            LowerSelectedTime = new DateTime(2023, 05, 12, 12, 0, 0),
            UpperSelectedTime = new DateTime(2023, 05, 16, 16, 0, 0),
            AddressId = AddressSeed.DomDamiraId.ToGuid(),
            UserId = UserSeed.DamirId.ToGuid()
        };
        yield return new
        {
            Id = DekoId.ToGuid(),
            TotalSum = 1000000m,
            Status = OrderStatus.InDelivery,
            DeadlineTime = new DateTime(2024, 10, 16, 16, 0, 0),
            LastUpdateTime = new DateTime(2023, 05, 12, 18, 10, 2),
            LowerSelectedTime = new DateTime(2023, 05, 10, 12, 0, 0),
            UpperSelectedTime = new DateTime(2024, 05, 16, 16, 0, 0),
            AddressId = AddressSeed.DomDekoId.ToGuid(),
            UserId = UserSeed.DamirId.ToGuid(),
            ExecutorId = UserSeed.RuslanId.ToGuid()
        };
    }

    private static IEnumerable<object> GetSeedInvoices()
    {
        yield return new
        {
            OrderId = KremlevskayaId.ToGuid(),
            Sum = 8600m,
            OperationTime = new DateTime(2023, 05, 12, 13, 0, 0)
        };
        yield return new
        {
            OrderId = DekoId.ToGuid(),
            Sum = 1000000m,
            OperationTime = new DateTime(2023, 05, 12, 13, 0, 0)
        };
    }

    private static IEnumerable<object> GetSeedOrderProducts()
    {
        yield return new
        {
            OrderId = KremlevskayaId.ToGuid(),
            ProductId = ProductSeed.AmericanoId.ToGuid(),
            Count = 3,
            Id = 1
        };
        yield return new
        {
            OrderId = DamirId.ToGuid(),
            ProductId = ProductSeed.LatteId.ToGuid(),
            Count = 10000,
            Id = 2
        };
        yield return new
        {
            OrderId = KremlevskayaId.ToGuid(),
            ProductId = ProductSeed.LatteId.ToGuid(),
            Count = 1,
            Id = 3
        };
        yield return new
        {
            OrderId = DekoId.ToGuid(),
            ProductId = ProductSeed.CappuccinoId.ToGuid(),
            Count = 1,
            Id = 4
        };
    }
}