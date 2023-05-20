using Main;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.AddCustomControllers();

builder.AddCustomDb();
builder.AddCustomIdentity();
builder.ConfigureCustomIdentityOptions();
builder.AddCustomOpenIddict();

services.AddEndpointsApiExplorer();

builder.AddCustomSwaggerGen();

builder.AddCustomAuthentication();
services.AddAuthorization();

builder.AddCustomApplicationServices();

services.AddCors(options =>
    options.AddPolicy("AllowSpecific", p => p.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()));

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