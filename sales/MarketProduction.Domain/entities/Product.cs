using System.ComponentModel.DataAnnotations;

namespace DataPulse.Domain.Entities;

public class Product
{
    // Identificador único (PK)
    public int ProductID { get; set; }

    [Required]
    [StringLength(100)]
    public string ProductName { get; set; } = string.Empty;

    // Llave foránea (FK) hacia la categoría
    public int CategoryID { get; set; }

    // Propiedad de navegación (Entity Framework la usa para los JOINs)
    public Category? Category { get; set; }

    [Range(0, double.MaxValue)]
    public decimal UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public bool Discontinued { get; set; }

    // Otros campos que vimos en tu diagrama:
    public string? QuantityPerUnit { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
}