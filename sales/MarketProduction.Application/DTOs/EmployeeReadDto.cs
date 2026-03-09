namespace DataPulse.Application.DTOs;

public record EmployeeReadDto(
    int EmployeeID,
    string FirstName,
    string LastName,
    string? Title,
    string? City,
    string? Country,
    string? HomePhone
);