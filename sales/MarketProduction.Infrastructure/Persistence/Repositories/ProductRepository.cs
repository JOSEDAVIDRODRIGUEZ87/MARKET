
namespace MarketProduction.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using MarketProduction.Application.Interfaces; // Para IProductRepository
using MarketProduction.Domain.Entities;         // Para Product
using MarketProduction.Infrastructure.Persistence; // Para AppDbContext
using Bogus;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) => _context = context;

    public async Task<(IEnumerable<Product>, int)> GetProductsAsync(int page, int pageSize)
    {
        var query = _context.Products.AsNoTracking();
        int total = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return (items, total);
    }
    public async Task AddBulkProductsAsync(int count, int categoryId)
    {
        // 1. Verificamos que la categoría realmente exista
        var categoryExists = await _context.Categories.AnyAsync(c => c.CategoryID == categoryId);

        if (!categoryExists)
        {
            throw new Exception($"La categoría con ID {categoryId} no existe. Por favor, créala primero.");
        }

        // 2. Si existe, procedemos con la lógica actual
        var faker = new Faker<Product>()
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 500))
            .RuleFor(p => p.CategoryID, categoryId);

        var products = faker.Generate(count);

        _context.ChangeTracker.AutoDetectChangesEnabled = false;
        await _context.Products.AddRangeAsync(products);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.AutoDetectChangesEnabled = true;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.ProductID == id);
    }
}