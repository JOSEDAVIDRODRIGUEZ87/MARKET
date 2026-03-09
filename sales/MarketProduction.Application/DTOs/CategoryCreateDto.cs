using System.ComponentModel.DataAnnotations;

namespace MarketProduction.Application.DTOs;
public class CategoryCreateDto {
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3)]
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Picture { get; set; }
}