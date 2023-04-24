using System.Reflection;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Main.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Main.Infrastructure;

public static class InfrastructureDependencies
{
    public static void ConfigureDb(WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services
            .Configure<DbOptions>(
                builder.Configuration.GetSection(DbOptions.DbConfiguration));

        var dbOptions = builder.Configuration.GetSection(DbOptions.DbConfiguration).Get<DbOptions>();

        services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(dbOptions!.ConnectionString,
                    action => action.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
                options.UseOpenIddict();
            })
            .AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    public static async Task ConfigureMigrations(WebApplication app)
    {
        await Policy.Handle<Exception>()
            .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(10),
                onRetry: (exception, retryTime) =>
                    Console.WriteLine($"Error on migration apply: {exception.Message} | Retry in {retryTime}"))
            .ExecuteAsync(async () =>
            {
                await using var scope = app.Services.CreateAsyncScope();
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                await context!.Database.MigrateAsync();
            });
    }
}