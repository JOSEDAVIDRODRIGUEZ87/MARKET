using System.ComponentModel.DataAnnotations;

namespace DataPulse.Application.DTOs;

public record SupplierCreateDto(
    [Required] [StringLength(40)] string CompanyName,
    [StringLength(30)] string? ContactName,
    [StringLength(30)] string? ContactTitle,
    [StringLength(60)] string? Address,
    [StringLength(15)] string? City,
    [StringLength(15)] string? Region,
    [StringLength(10)] string? PostalCode,
    [StringLength(15)] string? Country,
    [StringLength(24)] string? Phone,
    [StringLength(24)] string? Fax,
    string? HomePage
);