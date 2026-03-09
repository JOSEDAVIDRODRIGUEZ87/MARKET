using Bogus; // Asegúrate de tener instalado este paquete
using Microsoft.EntityFrameworkCore;
using MarketProduction.Domain.Entities;

namespace MarketProduction.Infrastructure.Persistence;

public static class SeedData
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // 1. Asegurar que la base de datos existe
        await context.Database.EnsureCreatedAsync();

        if (await context.Products.AnyAsync()) return;

        // 2. Crear categorías (si no existen)
        var categories = new List<Category>
        {
            new Category { CategoryName = "Electrónica" },
            new Category { CategoryName = "Hogar" }
        };
        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();

        // 3. Generación masiva con Bogus (100,000 registros)
        var productFaker = new Faker<Product>()
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.UnitsInStock, f => f.Random.Short(0, 100))
            .RuleFor(p => p.CategoryID, f => f.PickRandom(categories).CategoryID);

        var products = productFaker.Generate(100000);

        // 4. Inserción masiva
        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }
}