namespace MarketProduction.Application.DTOs;

public record CategoryReadDto(
    int CategoryID,
    string CategoryName,
    string? Description
// Nota: A veces no queremos enviar la "Picture" en una lista para no saturar la API.
);