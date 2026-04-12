using Application.Repository;
using Domain.Entity;

namespace Application.UseCases.GetOrderByNumber;

public class GetOrderByNumberUseCase(IOrderRepository orderRepository)
{
    public async Task<OrderEntity> Execute(int number) =>
        await orderRepository.GetByNumber(number)
        ?? throw new ArgumentException($"Order with number {number} not found");
}
