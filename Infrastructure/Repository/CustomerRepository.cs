using Application.Repository;
using Domain.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CustomerRepository(DirtyStoreDbContext dbContext)
    : BaseEntityRepository<CustomerEntity>(dbContext),
        ICustomerRepository
{
    public async Task<CustomerEntity?> GetById(Guid customerId) =>
        await dbContext.Customers.FindAsync(customerId);

    public new async Task Save(CustomerEntity customer) => await base.Save(customer);
}
