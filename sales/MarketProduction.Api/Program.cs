using Microsoft.EntityFrameworkCore; // Necesario para UseNpgsql
using MarketProduction.Infrastructure.Persistence; // Ajusta según el namespace de tu archivo AppDbContext

var builder = WebApplication.CreateBuilder(args);

// --- AGREGA ESTO ---
// Obtenemos la cadena de conexión del appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registramos el contexto para usar PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
// -------------------

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