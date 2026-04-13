using Application.Repository;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepository(DirtyStoreDbContext dbContext)
    : BaseEntityRepository<OrderDatabaseEntity>(dbContext),
        IOrderRepository
{
    public async Task<IEnumerable<OrderEntity>> GetAll() =>
        (
            await dbContext
                .Orders.Include(_ => _.Customer)
                .Include(_ => _.OrderItems)
                    .ThenInclude(item => item.Product)
                .ToListAsync()
        ).ConvertAll(order => order.ToOrderEntity());

    public async Task<OrderEntity?> GetByNumber(int number) =>
        (
            await dbContext
                .Orders.Include(_ => _.Customer)
                .Include(_ => _.OrderItems)
                    .ThenInclude(item => item.Product)
                .FirstOrDefaultAsync(_ => _.Number == number)
        )?.ToOrderEntity();

    public async Task<int> Save(OrderEntity order)
    {
        await Save(OrderDatabaseEntity.FromOrderEntity(order));
        return order.Number;
    }
}
