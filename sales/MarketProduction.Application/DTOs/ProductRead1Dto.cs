namespace MarketProduction.Application.DTOs;

public record ProductRead1Dto(
    int ProductID, 
    string ProductName, 
    decimal UnitPrice, 
    string CategoryName // Solo el nombre, no todo el objeto Category
);