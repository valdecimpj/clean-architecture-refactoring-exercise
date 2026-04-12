using Application.UseCases.CreateCustomer.Dto;

namespace Application.UseCases.CreateOrder;

public record CreateOrderRequest(Guid CustomerId, IEnumerable<OrderItemDto> OrderItems);
