using Microsoft.EntityFrameworkCore;
using MarketProduction.Domain.Entities;

namespace MarketProduction.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tablas de la base de datos
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Shipper> Shippers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Llave primaria compuesta para OrderDetail
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderID, od.ProductID });

        // Configuración de precisión para decimales (importante en Northwind)
        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");

        // Índices para optimizar las búsquedas masivas
        modelBuilder.Entity<Product>().HasIndex(p => p.ProductName);
    }
}