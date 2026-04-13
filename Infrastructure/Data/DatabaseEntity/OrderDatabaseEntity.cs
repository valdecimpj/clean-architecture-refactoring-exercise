using Domain.Enum;

namespace Domain.Entity;

public class OrderDatabaseEntity(int number, Guid customerId, OrderStatusEnum status)
{
    public int Number { get; set; } = number;
    public Guid CustomerId { get; set; } = customerId;
    public CustomerDatabaseEntity Customer { get; set; } = null!;
    public OrderStatusEnum Status { get; set; } = status;
    public IList<OrderItemDatabaseEntity> OrderItems { get; set; } = null!;

    public OrderEntity ToOrderEntity() =>
        new OrderEntity(
            Number,
            Customer.ToCustomerEntity(),
            Status,
            OrderItems.Select(item => item.ToOrderItemEntity()).ToList()
        );

    public static OrderDatabaseEntity FromOrderEntity(OrderEntity orderEntity) =>
        new(orderEntity.Number, orderEntity.Customer.Id, orderEntity.Status)
        {
            OrderItems = orderEntity
                .OrderItems.Select(OrderItemDatabaseEntity.FromOrderItemEntity)
                .ToList(),
        };
}
