using Application.Repository;

namespace Application.UseCases.CancelOrder;

public class CancelOrderUseCase(IOrderRepository orderRepository)
{
    public async Task<CancelOrderResponse> Execute(int number)
    {
        var order =
            await orderRepository.GetByNumber(number)
            ?? throw new ArgumentException($"Order with number {number} not found");

        order.Cancel();
        await orderRepository.Save(order);
        return new CancelOrderResponse($"Order with number {number} cancelled successfully");
    }
}
