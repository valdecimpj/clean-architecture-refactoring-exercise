namespace Application.UseCases.CreateCustomer;

public class CreateCustomerRequest(string name)
{
    public string Name { get; private set; } = name;
}
