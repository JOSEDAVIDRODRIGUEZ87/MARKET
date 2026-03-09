using System.ComponentModel.DataAnnotations;

namespace DataPulse.Application.DTOs;

public record OrderDetailCreateDto(
    [Required] int ProductID,
    [Required] [Range(1, short.MaxValue)] short Quantity,
    [Required] [Range(0, 1)] float Discount
);