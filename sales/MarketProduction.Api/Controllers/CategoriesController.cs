using Microsoft.AspNetCore.Mvc;
using MarketProduction.Application.Interfaces;
using MarketProduction.Application.DTOs;
using MarketProduction.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MarketProduction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    // Ruta diferenciada para Bulk: POST /api/categories/bulk
    [Authorize]
    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulk([FromBody] BulkRequest request)
    {
        await _repository.AddBulkProductsAsync(request.Count, request.CategoryId);
        return Ok(new { message = $"Se han procesado {request.Count} productos." });
    }

    // Ruta base para creación normal: POST /api/categories
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryCreateDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            Description = dto.Description,
            Picture = dto.Picture
        };

        await _repository.AddCategoryAsync(category);

        return CreatedAtAction(nameof(GetById), new { id = category.CategoryID }, new CategoryReadDto(
            category.CategoryID,
            category.CategoryName,
            category.Description
        ));
    }

    // He añadido un GetById para que CreatedAtAction funcione correctamente
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null) return NotFound();

        return Ok(new CategoryReadDto(category.CategoryID, category.CategoryName, category.Description));
    }
}