using Application.Repository;
using Domain.Entity;

namespace Application.UseCases.CreateProduct;

public class CreateProductUseCase(IProductRepository productRepository)
{
    public async Task<CreateProductResponse> Execute(CreateProductRequest createProductRequest)
    {
        var product = new ProductEntity(
            createProductRequest.Code,
            createProductRequest.Name,
            createProductRequest.Price
        );

        await productRepository.Save(product);

        return new($"Product {createProductRequest.Code} created successfully", product);
    }
}
