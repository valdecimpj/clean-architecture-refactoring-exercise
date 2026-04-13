namespace Domain.Entity;

public class OrderItemDatabaseEntity(
    int orderNumber,
    string productCode,
    int quantity,
    decimal total
)
{
    public int OrderNumber { get; set; } = orderNumber;
    public string ProductCode { get; set; } = productCode;
    public ProductDatabaseEntity Product { get; set; } = null!;
    public int Quantity { get; set; } = quantity;
    public decimal Total { get; set; } = total;

    public OrderItemEntity ToOrderItemEntity() =>
        new OrderItemEntity(Product.ToProductEntity(), Quantity, Total);

    public static OrderItemDatabaseEntity FromOrderItemEntity(OrderItemEntity orderItemEntity) =>
        new(0, orderItemEntity.Product.Code, orderItemEntity.Quantity, orderItemEntity.Total);
}
