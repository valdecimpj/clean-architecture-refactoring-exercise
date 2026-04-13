using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DirtyStoreDbContext : DbContext
{
    public DbSet<CustomerDatabaseEntity> Customers { get; set; }
    public DbSet<ProductDatabaseEntity> Products { get; set; }
    public DbSet<OrderDatabaseEntity> Orders { get; set; }
    public DbSet<OrderItemDatabaseEntity> OrderItems { get; set; }

    public DirtyStoreDbContext(DbContextOptions<DirtyStoreDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var orderEntity = modelBuilder.Entity<OrderDatabaseEntity>();
        orderEntity.HasKey(order => order.Number);
        orderEntity.Property(order => order.Number).ValueGeneratedOnAdd();
        orderEntity.HasMany(order => order.OrderItems);
        orderEntity.HasOne(order => order.Customer);

        var orderItemEntity = modelBuilder.Entity<OrderItemDatabaseEntity>();
        orderItemEntity.Property<Guid>("order_item_id").HasColumnType("uuid").ValueGeneratedOnAdd();
        orderItemEntity.HasKey("order_item_id");
        orderItemEntity.HasOne(item => item.Product);

        var productEntity = modelBuilder.Entity<ProductDatabaseEntity>();
        productEntity.HasKey(product => product.Code);

        var customerEntity = modelBuilder.Entity<CustomerDatabaseEntity>();
        customerEntity.HasKey(customer => customer.Id);
    }
}
