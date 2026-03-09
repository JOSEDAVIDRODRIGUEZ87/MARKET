using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketProduction.Application.Interfaces;
using MarketProduction.Application.DTOs;
using MarketProduction.Infrastructure.Persistence;
using MarketProduction.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MarketProduction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;
    private readonly AppDbContext _context;

    public ProductsController(IProductRepository repo, AppDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateBulk([FromBody] BulkRequest request)
    {
        // Se ha unificado el método eliminando el duplicado
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

        var dtoList = data.Select(p => new ProductRead1Dto(
            p.ProductID,
            p.ProductName,
            p.UnitPrice,
            p.Category?.CategoryName ?? "Sin categoría"
        )).ToList();

        return Ok(new { Total = total, Page = page, Items = dtoList });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _repo.GetByIdAsync(id);

        if (product == null)
            return NotFound(new { message = "Producto no encontrado." });

        var productDto = new ProductRead1Dto(
            product.ProductID,
            product.ProductName,
            product.UnitPrice,
            product.Category?.CategoryName ?? "Sin categoría"
        );

        return Ok(productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product productUpdate)
    {
        if (id != productUpdate.ProductID) return BadRequest("El ID no coincide.");

        var existingProduct = await _repo.GetByIdAsync(id);
        if (existingProduct == null) return NotFound();

        existingProduct.ProductName = productUpdate.ProductName;
        existingProduct.UnitPrice = productUpdate.UnitPrice;
        existingProduct.CategoryID = productUpdate.CategoryID;

        await _repo.UpdateAsync(existingProduct);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null) return NotFound();

        await _repo.DeleteAsync(id);
        return NoContent();
    }
}