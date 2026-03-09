namespace DataPulse.Application.DTOs;

public record ProductReadDto(
    int ProductID,
    string ProductName,
    string CategoryName, // Información enriquecida
    decimal UnitPrice,
    short? UnitsInStock,
    bool Discontinued
);