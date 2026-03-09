namespace MarketProduction.Application.DTOs;
using System.ComponentModel.DataAnnotations;

public class BulkRequest {
    [Range(1, 100000, ErrorMessage = "Debes solicitar entre 1 y 100,000 productos.")]
    public int Count { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}