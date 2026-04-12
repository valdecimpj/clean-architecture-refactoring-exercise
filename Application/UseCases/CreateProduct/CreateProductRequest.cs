namespace Application.UseCases.CreateProduct;

public class CreateProductRequest(string code, string name, decimal price)
{
    public string Code { get; private set; } = code;
    public string Name { get; private set; } = name;
    public decimal Price { get; private set; } = price;
}
