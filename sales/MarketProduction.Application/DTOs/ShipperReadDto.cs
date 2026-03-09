namespace DataPulse.Application.DTOs;

public record ShipperReadDto(
    int ShipperID,
    string CompanyName,
    string? Phone
);