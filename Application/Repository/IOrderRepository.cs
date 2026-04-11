using Domain.Entity;

namespace Application.Repository;

public interface IOrderRepository
{
    Task Save(OrderEntity order);
    Task<OrderEntity?> GetByNumber(int number);
    Task<IEnumerable<OrderEntity>> GetAll();
}