using Domain.Entity;

namespace Application.UseCases.CreateOrder;

public record CreateOrderResponse(string Response, OrderEntity Order, IEnumerable<string> Logs);
