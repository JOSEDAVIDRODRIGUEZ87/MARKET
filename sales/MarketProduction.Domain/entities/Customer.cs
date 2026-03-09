using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MarketProduction.Domain.Entities;

public class Customer
{
    // En el modelo Northwind original, el CustomerID es un string de 5 caracteres (ej: 'ALFKI')
    [Key]
    [StringLength(5)]
    public string CustomerID { get; set; } = string.Empty;

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(30)]
    public string? ContactName { get; set; }

    [StringLength(30)]
    public string? ContactTitle { get; set; } // Corregido de "ContacTitle"

    [StringLength(60)]
    public string? Address { get; set; }

    [StringLength(15)]
    public string? City { get; set; }

    [StringLength(15)]
    public string? Region { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }

    [StringLength(15)]
    public string? Country { get; set; }

    [StringLength(24)]
    public string? Phone { get; set; }

    [StringLength(24)]
    public string? Fax { get; set; }

    // Relación: Un cliente puede tener muchas órdenes
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}