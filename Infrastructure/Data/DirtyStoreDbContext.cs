using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DirtyStoreDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }

    public DirtyStoreDbContext(DbContextOptions<DirtyStoreDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var orderEntity = modelBuilder.Entity<OrderEntity>();
        orderEntity.HasKey(order => order.Number);
        orderEntity.Property(order => order.Number).ValueGeneratedOnAdd();
        orderEntity.HasMany(order => order.OrderItems);
        orderEntity.HasOne(order => order.Customer);

        var orderItemEntity = modelBuilder.Entity<OrderItemEntity>();
        orderItemEntity.Property<Guid>("order_item_id").HasColumnType("uuid").ValueGeneratedOnAdd();
        orderItemEntity.HasKey("order_item_id");
        orderItemEntity.HasOne(item => item.Product);

        var productEntity = modelBuilder.Entity<ProductEntity>();
        productEntity.HasKey(product => product.Code);

        var customerEntity = modelBuilder.Entity<CustomerEntity>();
        customerEntity.HasKey(customer => customer.Id);
    }
}
