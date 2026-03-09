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
    private readonly IProductRepository _repo; // Nombre correcto según tu constructor
    private readonly AppDbContext _context;

    public ProductsController(IProductRepository repo, AppDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBulk([FromBody] BulkRequest request)
    {
        await _repo.AddBulkProductsAsync(request.Count, request.CategoryId);
        return Ok(new { message = $"Se crearon {request.Count} productos correctamente." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 1, int size = 20, string? search = null)
    {
        var query = _context.Products.Include(p => p.Category).AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(p => p.ProductName.Contains(search));

        var total = await query.CountAsync();
        var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();

        // Mapeo de la lista a DTOs
        var dtoList = data.Select(p => new ProductRead1Dto(
            p.ProductID,
            p.ProductName,
            p.UnitPrice,
            p.Category?.CategoryName ?? "Sin categoría"
        )).ToList();

        return Ok(new { Total = total, Page = page, Items = dtoList });
    }

    // He combinado la lógica: eliminé el GetById original que causaba ciclo JSON
    // y mantuve el que utiliza tu nuevo DTO ProductRead1Dto.
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // Usamos el repositorio para obtener la entidad con su categoría
        var product = await _repo.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = "Producto no encontrado." });

        // Mapeo manual al DTO (esto soluciona el error de "A possible object cycle was detected")
        var productDto = new ProductRead1Dto(
            product.ProductID,
            product.ProductName,
            product.UnitPrice,
            product.Category?.CategoryName ?? "Sin categoría"
        );

        return Ok(productDto);
    }
}