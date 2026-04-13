using Domain.Enum;
using Domain.Exceptions;

namespace Domain.Entity;

public class OrderEntity
{
    public int Number { get; private set; }
    public CustomerEntity Customer { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public IList<OrderItemEntity> OrderItems { get; private set; }
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
        OrderItems = orderItemEntities;
        Validate();
    }

    private void Validate()
    {
        if (!OrderItems.Any())
            throw new BadUserInputException("Order must have at least one item");
    }

    public void Cancel()
    {
        if (Status == OrderStatusEnum.Cancelled)
            throw new BadUserInputException("Order is already cancelled");

        Status = OrderStatusEnum.Cancelled;
    }
}
