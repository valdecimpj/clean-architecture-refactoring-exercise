using Application.Repository;
using Application.UseCases.CreateCustomer.Dto;
using Domain.Entity;
using Domain.Enum;
using Domain.Exceptions;

namespace Application.UseCases.CreateOrder;

public class CreateOrderUseCase(
    ICustomerRepository customerRepository,
    IProductRepository productRepository,
    IOrderRepository orderRepository,
    ISessionLogRepository sessionLogRepository
)
{
    public async Task<CreateOrderResponse> Execute(CreateOrderRequest createOrderRequest)
    {
        var customer =
            await customerRepository.GetById(createOrderRequest.CustomerId)
            ?? throw new BadUserInputException("Customer not found with the provided ID");

        List<OrderItemDto> nonZeroQuantityItems = new();

        foreach (var orderItem in createOrderRequest.OrderItems)
        {
            if (orderItem.Quantity > 0)
                nonZeroQuantityItems.Add(orderItem);
            else
                await sessionLogRepository.Save(
                    $"Order item with index {createOrderRequest.OrderItems.IndexOf(orderItem) + 1} and product code {orderItem.ProductCode} has zero quantity and will be ignored."
                );
        }

        var products = await productRepository.GetByCodes(
            nonZeroQuantityItems.Select(_ => _.ProductCode),
            throwIfNotFound: true
        );

        var orderItemEntities = nonZeroQuantityItems
            .Select(orderItem =>
            {
                var product = products.First(_ => _.Code == orderItem.ProductCode);
                return new OrderItemEntity(product, orderItem.Quantity);
            })
            .ToList();

        var order = new OrderEntity(customer, OrderStatusEnum.Open, orderItemEntities);
        var orderNumber = await orderRepository.Create(order);
        var savedOrder = await orderRepository.GetByNumber(orderNumber);

        return new(
            $"Order {orderNumber} with total value {order.TotalValue} created successfully",
            savedOrder!,
            await sessionLogRepository.GetForSession()
        );
    }
}
