using System.ComponentModel.DataAnnotations;

namespace DataPulse.Application.DTOs;

public record ShipperCreateDto(
    [Required] [StringLength(40)] string CompanyName,
    [StringLength(24)] string? Phone
);