namespace Domain.Entity;

public class OrderItemEntity
{
    public ProductEntity ProductEntity { get; private set; }
    public int Quantity { get; private set; }
    public decimal Total { get; private set; }
    public decimal UnitPrice => Total / Quantity;

    public OrderItemEntity(ProductEntity productEntity, int quantity)
    {
        ProductEntity = productEntity;
        Quantity = quantity;
        Total = productEntity.Price * quantity;
        Validate();
    }

    public OrderItemEntity(ProductEntity productEntity, int quantity, decimal total)
    {
        ProductEntity = productEntity;
        Quantity = quantity;
        Total = total;
        Validate();
    }

    private void Validate()
    {
        if (Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (Total < 0)
            throw new ArgumentException("Total must be positive");
    }
}
