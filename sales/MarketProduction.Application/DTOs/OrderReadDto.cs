namespace DataPulse.Application.DTOs;

public record OrderReadDto(
    int OrderID,
    string CustomerID,
    DateTime? OrderDate,
    DateTime? ShippedDate,
    decimal? Freight,
    string? ShipName
);