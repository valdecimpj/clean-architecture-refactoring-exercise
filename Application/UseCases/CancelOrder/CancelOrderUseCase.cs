using Application.Repository;
using Domain.Exceptions;

namespace Application.UseCases.CancelOrder;

public class CancelOrderUseCase(IOrderRepository orderRepository)
{
    public async Task<CancelOrderResponse> Execute(int number)
    {
        var order =
            await orderRepository.GetByNumber(number)
            ?? throw new BadUserInputException($"Order with number {number} not found");

        order.Cancel();
        await orderRepository.Update(order);
        return new CancelOrderResponse($"Order with number {number} cancelled successfully");
    }
}
