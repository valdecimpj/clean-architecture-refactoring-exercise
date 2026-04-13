using Application.Repository;
using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CustomerRepository(DirtyStoreDbContext dbContext)
    : BaseEntityRepository<CustomerDatabaseEntity>(dbContext),
        ICustomerRepository
{
    public async Task<CustomerEntity?> GetById(Guid customerId) =>
        (await dbContext.Customers.FindAsync(customerId))?.ToCustomerEntity();

    public async Task Save(CustomerEntity customer) =>
        await Save(CustomerDatabaseEntity.FromCustomerEntity(customer));
}
