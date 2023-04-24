using Main.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

InfrastructureDependencies.ConfigureDb(builder);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthorization();

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