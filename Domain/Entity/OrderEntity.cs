using Domain.Enum;

namespace Domain.Entity;

public class OrderEntity
{
    public int Number { get; private set; }
    public CustomerEntity Customer { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public IList<OrderItemEntity> OrderItemEntities { get; private set; }
    public decimal TotalValue => OrderItemEntities.Sum(item => item.Total);

    public OrderEntity(
        CustomerEntity customer,
        OrderStatusEnum status,
        IList<OrderItemEntity> orderItemEntities
    )
    {
        Number = 0;
        Customer = customer;
        Status = status;
        OrderItemEntities = orderItemEntities;
        Validate();
    }

    public OrderEntity(
        int number,
        CustomerEntity customer,
        OrderStatusEnum status,
        IList<OrderItemEntity> orderItemEntities
    )
    {
        Number = number;
        Customer = customer;
        Status = status;
        OrderItemEntities = orderItemEntities;
        Validate();
    }

    private void Validate()
    {
        if (Number <= 0)
            throw new ArgumentException("Order number must be greater than zero");

        if (!OrderItemEntities.Any())
            throw new ArgumentException("Order must have at least one item");
    }

    public void Cancel()
    {
        if (Status == OrderStatusEnum.Cancelled)
            throw new InvalidOperationException("Order is already cancelled");

        Status = OrderStatusEnum.Cancelled;
    }
}
