using Main;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

builder.AddCustomDb();
builder.AddCustomIdentity();
builder.ConfigureCustomIdentityOptions();
builder.AddCustomOpenIddict();

services.AddEndpointsApiExplorer();

builder.AddCustomSwaggerGen();

builder.AddCustomAuthentication();
services.AddAuthorization();

builder.AddCustomApplicationServices();

builder.AddCustomAutoMapper();

services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.MigrateDbContext();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();