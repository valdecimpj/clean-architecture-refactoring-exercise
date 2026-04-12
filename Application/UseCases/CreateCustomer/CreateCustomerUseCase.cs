using Application.Repository;
using Domain.Entity;

namespace Application.UseCases.CreateCustomer;

public class CreateCustomerUseCase(ICustomerRepository customerRepository)
{
    public async Task<CreateCustomerResponse> Execute(CreateCustomerRequest createCustomerRequest)
    {
        var customer = new CustomerEntity(createCustomerRequest.Name);
        await customerRepository.Save(customer);
        return new($"Customer {customer.Id} created successfully", customer);
    }
}
