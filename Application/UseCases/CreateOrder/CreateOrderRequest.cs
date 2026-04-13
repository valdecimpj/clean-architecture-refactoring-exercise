using Application.UseCases.CreateCustomer.Dto;

namespace Application.UseCases.CreateOrder;

public record CreateOrderRequest(Guid CustomerId, IList<OrderItemDto> OrderItems);
