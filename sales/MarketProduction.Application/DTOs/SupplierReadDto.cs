namespace DataPulse.Application.DTOs;

public record SupplierReadDto(
    int SupplierID,
    string CompanyName,
    string? ContactName,
    string? City,
    string? Country,
    string? Phone
);