using Application.Repository;
using Domain.Entity;

namespace Application.UseCases.GetAllOrders;

public class GetAllOrdersUseCase(IOrderRepository orderRepository)
{
    public async Task<IEnumerable<OrderEntity>> Execute() => await orderRepository.GetAll();
}
