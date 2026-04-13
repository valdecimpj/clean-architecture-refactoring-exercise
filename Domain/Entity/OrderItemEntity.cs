namespace Domain.Entity;

public class OrderItemEntity
{
    public ProductEntity Product { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal Total { get; private set; }
    public decimal UnitPrice => Total / Quantity;

    public OrderItemEntity(ProductEntity productEntity, int quantity)
    {
        Product = productEntity;
        Quantity = quantity;
        Total = productEntity.Price * quantity;
        Validate();
    }

    public OrderItemEntity(int quantity, decimal total)
    {
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
