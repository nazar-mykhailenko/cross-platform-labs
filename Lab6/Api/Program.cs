using Lab6.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
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

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

