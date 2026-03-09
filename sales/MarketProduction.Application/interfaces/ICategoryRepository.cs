using MarketProduction.Domain.Entities;
namespace MarketProduction.Application.Interfaces;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task<Category?> GetByIdAsync(int id);
}