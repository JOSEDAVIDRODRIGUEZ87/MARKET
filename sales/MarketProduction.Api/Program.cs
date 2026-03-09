var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor (Inyección de Dependencias)
builder.Services.AddControllers();

// Configuración de Swagger para documentar tu API (Súper importante para la prueba)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Configurar el pipeline de solicitudes HTTP (Middlewares)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Esto es vital para el requerimiento de Seguridad que te pidieron
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();