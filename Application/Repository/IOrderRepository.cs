using Domain.Entity;

namespace Application.Repository;

public interface IOrderRepository
{
    Task<int> Create(OrderEntity order);
    Task Update(OrderEntity order);
    Task<OrderEntity?> GetByNumber(int number);
    Task<IEnumerable<OrderEntity>> GetAll();
}
