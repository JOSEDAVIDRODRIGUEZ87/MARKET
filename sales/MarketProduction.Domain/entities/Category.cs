using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketProduction.Domain.Entities;

public class Category
{
    // Identificador único (PK) - Corregido el nombre a CategoryID
    public int CategoryID { get; set; }

    [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
    [StringLength(15)]
    public string CategoryName { get; set; } = string.Empty;

    public string? Description { get; set; }

    // En el modelo original, Picture suele ser una ruta o un arreglo de bytes (byte[])
    // Si guardarás la URL de la imagen, string es correcto.
    public string? Picture { get; set; }

    // Relación: Una categoría tiene muchos productos
    // Esto es fundamental para que Entity Framework entienda el diagrama que enviaste
    public ICollection<Product> Products { get; set; } = new List<Product>();
}