using MarketProduction.Application.Interfaces;
using MarketProduction.Domain.Entities;
using MarketProduction.Infrastructure.Persistence;

namespace MarketProduction.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository 
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    // ESTE ES EL MÉTODO QUE FALTABA
    public async Task AddBulkProductsAsync(int count, int categoryId)
    {
        // Implementa aquí la lógica necesaria, por ejemplo:
        // Si no necesitas hacer nada especial para categorías, 
        // puedes dejarlo vacío o lanzar una excepción de "no implementado".
        await Task.CompletedTask; 
    }
}