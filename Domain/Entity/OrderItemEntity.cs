namespace Domain.Entity;

public class OrderItemEntity(ProductEntity productEntity, int quantity, decimal total)
{
    public ProductEntity ProductEntity { get; private set;} = productEntity;
    public int Quantity { get; private set;} = quantity;
    public decimal Total { get; private set;} = total;
}