# Marketplace API

API desarrollada en ASP.NET Core para la gestión de productos y categorías de un marketplace.

## Tecnologías
- .NET 8/9
- Entity Framework Core
- PostgreSQL
- Swagger/OpenAPI

## Características
- Gestión de productos (CRUD completo).
- Carga masiva de productos (Bulk Insert).
- Paginación de resultados.

## Escalabilidad y Performance
- **Caching:** Implementación de Redis para reducir consultas a BD.
- **Bulk Operations:** Optimizado para inserciones masivas.
- **Escalabilidad Horizontal:** Preparado para despliegue en Kubernetes (K8s) con HPA (Horizontal Pod Autoscaler).

## Cómo ejecutar
1. Configurar la cadena de conexión en `appsettings.json`.
2. Ejecutar `dotnet run --project MarketProduction.Api`.
3. Visitar `http://localhost:5039/swagger` para probar los endpoints.