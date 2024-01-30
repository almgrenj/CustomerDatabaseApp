using CustomerDatabaseApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<SupplierEntity> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<OrderEntity>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<OrderItemEntity>()
            .Property(oi => oi.Price)
            .HasColumnType("decimal(18, 2)");

    }
}
