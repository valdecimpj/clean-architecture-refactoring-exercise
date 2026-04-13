using Application.Repository;
using Domain.Entity;
using Domain.Exceptions;

namespace Application.UseCases.GetOrderByNumber;

public class GetOrderByNumberUseCase(IOrderRepository orderRepository)
{
    public async Task<OrderEntity> Execute(int number) =>
        await orderRepository.GetByNumber(number)
        ?? throw new BadUserInputException($"Order with number {number} not found");
}
