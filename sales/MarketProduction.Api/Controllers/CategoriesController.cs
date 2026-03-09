using Microsoft.AspNetCore.Mvc;
using MarketProduction.Application.Interfaces;
using MarketProduction.Application.DTOs;
using MarketProduction.Domain.Entities;

namespace MarketProduction.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    // El constructor inicializa el repositorio que el sistema inyecta
    public CategoriesController(ICategoryRepository repository)
    {
        _repository = repository;
    }

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
        
        return Ok(new CategoryReadDto(
            category.CategoryID,
            category.CategoryName,
            category.Description
        ));
    }
}