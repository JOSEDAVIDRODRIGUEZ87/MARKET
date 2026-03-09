using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MarketProduction.Domain.Entities;

public class Supplier
{
    // Identificador único (PK)
    public int SupplierID { get; set; }

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = string.Empty; // Faltaba este campo del diagrama

    [StringLength(30)]
    public string? ContactName { get; set; }

    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [StringLength(60)]
    public string? Address { get; set; }

    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; } // Mejor string: códigos postales pueden tener letras o guiones

    [StringLength(15)]
    public string? Country { get; set; } // Corregido: era "Contry"

    [StringLength(24)]
    public string? Phone { get; set; }

    [StringLength(24)]
    public string? Fax { get; set; }

    public string? HomePage { get; set; }

    // Relación: Un proveedor suministra muchos productos
    public ICollection<Product> Products { get; set; } = new List<Product>();
}