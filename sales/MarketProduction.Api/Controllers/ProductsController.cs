using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketProduction.Application.Interfaces;
using MarketProduction.Application.DTOs;
using MarketProduction.Infrastructure.Persistence;
using MarketProduction.Domain.Entities;

namespace MarketProduction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;
    private readonly AppDbContext _context;

    // Inyectamos ambos: el repositorio para operaciones lógicas y el context para consultas rápidas
    public ProductsController(IProductRepository repo, AppDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBulk([FromBody] BulkRequest request)
    {
        // Delegamos la carga masiva al repositorio
        await _repo.AddBulkProductsAsync(request.Count, request.CategoryId);
        return Ok(new { message = $"Se crearon {request.Count} productos correctamente." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 1, int size = 20, string? search = null)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.ProductName.Contains(search));

        // Aplicamos paginación usando EF Core
        var total = await query.CountAsync();
        var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();

        return Ok(new { Total = total, Page = page, Items = data });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category) // JOIN con la tabla de categorías
            .FirstOrDefaultAsync(p => p.ProductID == id);

        return product != null ? Ok(product) : NotFound(new { message = "Producto no encontrado." });
    }
}