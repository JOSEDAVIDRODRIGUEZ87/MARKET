namespace DataPulse.Application.DTOs;

public record OrderCreateDto(
    string CustomerID,
    int? EmployeeID,
    int? ShipVia,
    DateTime? RequiredDate,
    decimal? Freight,
    string? ShipName,
    string? ShipAddress,
    string? ShipCity,
    string? ShipPostalCode,
    string? ShipCountry,
    List<OrderDetailCreateDto> OrderDetails // Lista de items del pedido
);