using Domain.Entity;

namespace Application.UseCases.CreateProduct;

public record CreateProductResponse(string Message, ProductEntity Product);
