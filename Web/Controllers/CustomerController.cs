using Application.UseCases.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateCustomerResponse>> Create(
        [FromBody] CreateCustomerRequest createCustomerRequest,
        [FromServices] CreateCustomerUseCase createCustomerUseCase
    ) => Ok(await createCustomerUseCase.Execute(createCustomerRequest));
}
