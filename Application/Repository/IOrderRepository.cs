using Domain.Entity;

namespace Application.Repository;

public interface IOrderRepository
{
    Task<int> Save(OrderEntity order);
    Task<OrderEntity?> GetByNumber(int number);
    Task<IEnumerable<OrderEntity>> GetAll();
}
