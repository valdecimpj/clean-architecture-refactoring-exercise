namespace Domain.Entity;

public class OrderItemDatabaseEntity(int quantity, decimal total)
{
    public ProductDatabaseEntity Product { get; set; } = null!;
    public int Quantity { get; set; } = quantity;
    public decimal Total { get; set; } = total;

    public OrderItemEntity ToOrderItemEntity() =>
        new OrderItemEntity(Product.ToProductEntity(), Quantity, Total);

    public static OrderItemDatabaseEntity FromOrderItemEntity(OrderItemEntity orderItemEntity) =>
        new(orderItemEntity.Quantity, orderItemEntity.Total);
}
