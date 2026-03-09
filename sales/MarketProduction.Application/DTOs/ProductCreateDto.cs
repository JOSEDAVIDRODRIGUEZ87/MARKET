using System.ComponentModel.DataAnnotations;

namespace DataPulse.Application.DTOs;

public record ProductCreateDto(
    [Required] [StringLength(100)] string ProductName,
    [Required] int CategoryID,
    [Range(0, double.MaxValue)] decimal UnitPrice,
    short? UnitsInStock,
    string? QuantityPerUnit,
    short? ReorderLevel
);