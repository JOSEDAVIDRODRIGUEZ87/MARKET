using MarketProduction.Domain.Entities;
namespace MarketProduction.Application.Interfaces;

public interface ICategoryRepository
{
    Task AddBulkProductsAsync(int count, int categoryId);
    Task AddCategoryAsync(Category category);
    Task<Category?> GetByIdAsync(int id);
}