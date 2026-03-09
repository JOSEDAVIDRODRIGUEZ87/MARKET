using MarketProduction.Application.Interfaces; // Obligatorio
using MarketProduction.Domain.Entities;         // Obligatorio
using MarketProduction.Infrastructure.Persistence; // Donde vive tu AppDbContext

namespace MarketProduction.Infrastructure.Persistence.Repositories; // Debe ser este namespace

public class CategoryRepository : ICategoryRepository // ¡Asegúrate de que diga PUBLIC!
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
}