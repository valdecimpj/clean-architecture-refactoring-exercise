namespace Domain.Entity;

public class ProductEntity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public ProductEntity(string code, string name, decimal price)
    {
        Code = code;
        Name = name;
        Price = price;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new ArgumentException("Code cannot be empty");

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Name cannot be empty");

        if (Price < 0)
            throw new ArgumentException("Price must be positive");
    }
}
