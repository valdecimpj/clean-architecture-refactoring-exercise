using Domain.Enum;

namespace Domain.Entity;

public class OrderEntity
{
    public int Number { get; private set; }
    public CustomerEntity Customer { get; private set; } = null!;
    public OrderStatusEnum Status { get; private set; }
    public IList<OrderItemEntity> OrderItems { get; private set; } = null!;
    public decimal TotalValue => OrderItems.Sum(item => item.Total);

    public OrderEntity(
        CustomerEntity customer,
        OrderStatusEnum status,
        IList<OrderItemEntity> orderItemEntities
    )
    {
        Number = 0;
        Customer = customer;
        Status = status;
        OrderItems = orderItemEntities;
        Validate();
    }

    public OrderEntity(int number, OrderStatusEnum status)
    {
        Number = number;
        Status = status;
        Validate();
    }

    private void Validate()
    {
        if (Number <= 0)
            throw new ArgumentException("Order number must be greater than zero");

        if (!OrderItems.Any())
            throw new ArgumentException("Order must have at least one item");
    }

    public void Cancel()
    {
        if (Status == OrderStatusEnum.Cancelled)
            throw new InvalidOperationException("Order is already cancelled");

        Status = OrderStatusEnum.Cancelled;
    }
}
