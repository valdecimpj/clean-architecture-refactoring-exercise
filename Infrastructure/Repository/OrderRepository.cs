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

    public async Task<int> Create(OrderEntity order)
    {
        var orderDatabaseEntity = OrderDatabaseEntity.FromOrderEntity(order);
        var savedOrder = await Create(orderDatabaseEntity);
        return savedOrder.Number;
    }

    public async Task Update(OrderEntity order)
    {
        var orderDatabaseEntity = OrderDatabaseEntity.FromOrderEntity(order);
        await Update(orderDatabaseEntity);
    }
}
