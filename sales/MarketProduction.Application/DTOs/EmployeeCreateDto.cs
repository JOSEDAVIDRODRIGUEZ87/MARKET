using System.ComponentModel.DataAnnotations;

namespace DataPulse.Application.DTOs;

public record EmployeeCreateDto(
    [Required][StringLength(20)] string LastName,
    [Required][StringLength(10)] string FirstName,
    [StringLength(30)] string? Title,
    [StringLength(25)] string? TitleOfCourtesy,
    DateTime? BirthDate,
    DateTime? HireDate,
    [StringLength(60)] string? Address,
    [StringLength(15)] string? City,
    [StringLength(15)] string? Region,
    [StringLength(10)] string? PostalCode,
    [StringLength(15)] string? Country,
    [StringLength(24)] string? HomePhone,
    [StringLength(4)] string? Extension,
    string? Photo,
    string? Notes,
    int? ReportsTo
);