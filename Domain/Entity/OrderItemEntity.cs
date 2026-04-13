namespace Domain.Entity;

public class OrderItemEntity
{
    public ProductEntity Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Total { get; private set; }
    public decimal UnitPriceWhenPurchased => Total / Quantity;

    public OrderItemEntity(ProductEntity productEntity, int quantity)
    {
        Product = productEntity;
        Quantity = quantity;
        Total = productEntity.CurrentPrice * quantity;
        Validate();
    }

    public OrderItemEntity(ProductEntity productEntity, int quantity, decimal total)
    {
        Product = productEntity;
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
