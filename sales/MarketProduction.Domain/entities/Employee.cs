using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPulse.Domain.Entities;

public class Employee
{
    // Identificador único (PK)
    public int EmployeeID { get; set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(30)]
    public string? Title { get; set; }

    [StringLength(25)]
    public string? TitleOfCourtesy { get; set; }

    public DateTime? BirthDate { get; set; } // Corregido de "BrithDate"

    public DateTime? HireDate { get; set; }

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
    public string? HomePhone { get; set; }

    [StringLength(4)]
    public string? Extension { get; set; }

    public string? Photo { get; set; } // En Northwind original es un path o binario

    public string? Notes { get; set; }

    // Relación de Autoreferencia (ReportsTo)
    // En el diagrama, un empleado reporta a otro empleado
    public int? ReportsTo { get; set; } // Cambiado de string a int para la FK

    [ForeignKey("ReportsTo")]
    public virtual Employee? Manager { get; set; }

    // Relaciones: Un empleado puede tener muchas órdenes
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}