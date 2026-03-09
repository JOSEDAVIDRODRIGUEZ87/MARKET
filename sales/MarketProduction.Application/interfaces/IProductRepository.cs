using MarketProduction.Domain.Entities;

namespace MarketProduction.Application.Interfaces;

public interface IProductRepository 
{
    // Firma corregida para coincidir con la implementación de tu ProductRepository
    Task<(IEnumerable<Product> Items, int Total)> GetProductsAsync(int page, int pageSize);

    Task<Product?> GetByIdAsync(int id);
    
    // Agregamos la firma del método para la carga masiva que implementaste
    Task AddBulkProductsAsync(int count, int categoryId);
}