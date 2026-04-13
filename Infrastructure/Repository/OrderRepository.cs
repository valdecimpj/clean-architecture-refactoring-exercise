using Application.Repository;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepository(DirtyStoreDbContext dbContext)
    : BaseEntityRepository<OrderEntity>(dbContext),
        IOrderRepository
{
    public async Task<IEnumerable<OrderEntity>> GetAll() => await dbContext.Orders.ToListAsync();

    public async Task<OrderEntity?> GetByNumber(int number) =>
        await dbContext
            .Orders.Include(_ => _.OrderItems)
                .ThenInclude(item => item.Product)
            .FirstOrDefaultAsync(_ => _.Number == number);

    public new async Task<int> Save(OrderEntity order)
    {
        await base.Save(order);
        return order.Number;
    }
}
