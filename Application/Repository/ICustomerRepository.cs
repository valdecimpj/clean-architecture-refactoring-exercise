using Domain.Entity;

namespace Application.Repository;

public interface ICustomerRepository
{
    Task<CustomerEntity?> GetById(Guid customerId);
    Task Save(CustomerEntity customer);
}
