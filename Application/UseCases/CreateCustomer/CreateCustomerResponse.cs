using Domain.Entity;

namespace Application.UseCases.CreateCustomer;

public record CreateCustomerResponse(string Message, CustomerEntity Customer);
