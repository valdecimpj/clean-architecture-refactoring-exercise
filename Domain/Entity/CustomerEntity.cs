using Domain.Exceptions;

namespace Domain.Entity;

public class CustomerEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public CustomerEntity(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
        Validate();
    }

    public CustomerEntity(Guid id, string name)
    {
        Id = id;
        Name = name;
        Validate();
    }

    private void Validate()
    {
        if (Id == Guid.Empty)
            throw new BadUserInputException("Id cannot be empty");

        if (string.IsNullOrWhiteSpace(Name))
            throw new BadUserInputException("Name cannot be empty");
    }
}
