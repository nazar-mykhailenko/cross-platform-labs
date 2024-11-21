using Lab6.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var dbProvider = builder.Configuration["DBProvider"]?.ToLowerInvariant();
builder.Services.AddDbContext<AppDbContext>(opt => {
    switch (dbProvider)
    {
        case "sqlite":
            opt.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
            break;
        case "sqlserver":
            opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
            break;
        case "postgresql":
            opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
            break;
        case "inmemory":
            opt.UseInMemoryDatabase("InMemory");
            break;
        default:
            throw new InvalidOperationException("Invalid database provider");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}