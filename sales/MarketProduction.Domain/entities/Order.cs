using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPulse.Domain.Entities;

public class Order
{
    // Identificador único (PK)
    public int OrderID { get; set; }

    // Llaves Foráneas (FK)
    [Required]
    public string CustomerID { get; set; } = string.Empty; // En Northwind, CustomerID suele ser string

    public int? EmployeeID { get; set; } // Corregido de "EmployedId" a "EmployeeID"

    // Fechas: En C# usamos DateTime o DateTimeOffset
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; } // Corregido de "RequireDate"
    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; } // Suele ser una FK hacia la tabla Shippers

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Freight { get; set; } // Cambiado de string a decimal para cálculos financieros

    [StringLength(40)]
    public string? ShipName { get; set; }

    [StringLength(60)]
    public string? ShipAddress { get; set; }

    [StringLength(15)]
    public string? ShipCity { get; set; }

    [StringLength(15)]
    public string? ShipRegion { get; set; }

    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [StringLength(15)]
    public string? ShipCountry { get; set; }

    // Propiedades de Navegación (Relaciones del diagrama)
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}