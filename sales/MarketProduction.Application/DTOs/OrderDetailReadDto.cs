namespace DataPulse.Application.DTOs;

public record OrderDetailReadDto(
    int ProductID,
    string ProductName, // Incluimos el nombre para que el cliente no tenga que buscar el ID
    decimal UnitPrice,
    short Quantity,
    float Discount
);