using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataPulse.Domain.Entities;

public class Shipper
{
    // Identificador único (PK)
    public int ShipperID { get; set; }

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(24)]
    public string? Phone { get; set; }

    // Relación: Una empresa de envío (Shipper) puede entregar muchas órdenes
    // En la tabla Order, esta relación se conecta mediante el campo 'ShipVia'
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}