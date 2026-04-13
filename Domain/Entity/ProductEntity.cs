namespace Domain.Entity;

public class ProductEntity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal CurrentPrice { get; private set; }

    public ProductEntity(string code, string name, decimal currentPrice)
    {
        Code = code;
        Name = name;
        CurrentPrice = currentPrice;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Code))
            throw new ArgumentException("Code cannot be empty");

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentException("Name cannot be empty");

        if (CurrentPrice < 0)
            throw new ArgumentException("Current price must be positive");
    }
}
