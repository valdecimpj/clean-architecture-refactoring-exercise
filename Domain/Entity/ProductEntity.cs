using Domain.Exceptions;

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
            throw new BadUserInputException("Code cannot be empty");

        if (string.IsNullOrWhiteSpace(Name))
            throw new BadUserInputException("Name cannot be empty");

        if (CurrentPrice < 0)
            throw new BadUserInputException("Current price must be positive");
    }
}
