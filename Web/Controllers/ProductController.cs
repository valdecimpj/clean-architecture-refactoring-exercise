using Application.UseCases.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(
        [FromBody] CreateProductRequest createProductRequest,
        [FromServices] CreateProductUseCase createProductUseCase
    ) => Ok(await createProductUseCase.Execute(createProductRequest));
}
