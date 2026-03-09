using Microsoft.EntityFrameworkCore; // Necesario para UseNpgsql
using MarketProduction.Infrastructure.Persistence; // Ajusta según el namespace de tu archivo AppDbContext
using MarketProduction.Infrastructure.Persistence.Repositories;
using MarketProduction.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// --- AGREGA ESTO ---
// Obtenemos la cadena de conexión del appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registramos el contexto para usar PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<MarketProduction.Application.Interfaces.IProductRepository, MarketProduction.Infrastructure.Persistence.Repositories.ProductRepository>();
// ---------------------------------------------------
// -------------------
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();