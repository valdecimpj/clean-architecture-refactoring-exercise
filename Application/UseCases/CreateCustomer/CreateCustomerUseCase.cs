using Application.Repository;

namespace Application.UseCases.CreateCustomer;

public class CreateCustomerUseCase(ICustomerRepository customerRepository)
{
    public async Task<CreateCustomerResponse> Execute(CreateCustomerRequest createCustomerRequest)
    {
        await customerRepository.Save(new(createCustomerRequest.Name));
        return new("Customer created successfully");
    }
}
