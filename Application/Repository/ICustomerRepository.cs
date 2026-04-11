using Domain.Entity;

namespace Application.Repository;

public interface ICustomerRepository
{
    Task Save(CustomerEntity customer);
}