using Microsoft.EntityFrameworkCore;
using Users.Entities.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

string? host = Environment.GetEnvironmentVariable("DATABASE_HOST");
string port = "5432";
string? name = Environment.GetEnvironmentVariable("DATABASE_NAME");
string? user = Environment.GetEnvironmentVariable("DATABASE_USER");
string? password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(
        "Host=" + host + ";Port=" + port + ";Database=" + name + ";Username=" + user + ";Password=" + password + ";"
    ));

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.ApplyMigrations();
app.Run();
