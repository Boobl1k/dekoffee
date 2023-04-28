using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure;
using Main.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

InfrastructureDependencies.ConfigureDb(builder);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthorization();

services.AddTransient<ILoginService<User>, LoginService>();
services.AddTransient<IProductService<Product>, ProductService>();
services.AddTransient<ICartService, CartService>();
services.AddTransient<IProfileService<User>, ProfileService>();

services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await InfrastructureDependencies.ConfigureMigrations(app);

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();