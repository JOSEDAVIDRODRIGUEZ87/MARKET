namespace DataPulse.Application.DTOs;

public record CustomerReadDto(
    string CustomerID,
    string CompanyName,
    string? ContactName,
    string? City,
    string? Country,
    string? Phone
);