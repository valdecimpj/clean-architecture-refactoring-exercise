using Domain.Enum;

namespace Domain.Entity;

public class OrderEntity(
    int number,
    CustomerEntity customer,
    OrderStatusEnum status,
    IList<OrderItemEntity> orderItemEntities)
{
    public int Number { get; private set; } = number;
    public CustomerEntity Customer { get; private set; } = customer;
    public OrderStatusEnum Status { get; private set; } = status;
    public IList<OrderItemEntity> OrderItemEntities { get; private set; } = orderItemEntities;
}