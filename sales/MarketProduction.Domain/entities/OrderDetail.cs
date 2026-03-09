
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPulse.Domain.Entities;

public class OrderDetail
{
    // Llave Primaria Compuesta (OrderID + ProductID)
    [Required]
    public int OrderID { get; set; }

    // Propiedad de navegación hacia la Orden
    public virtual Order Order { get; set; } = null!;

    [Required]
    public int ProductID { get; set; }

    // Propiedad de navegación hacia el Producto
    public virtual Product Product { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; } // El precio al momento de la compra

    [Required]
    public short Quantity { get; set; } // Usamos short como en el diagrama original

    [Required]
    public float Discount { get; set; } // El descuento suele ser un porcentaje (0 a 1)
}