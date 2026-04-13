namespace Domain.Entity;

public class CustomerDatabaseEntity(Guid id, string name)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;

    public CustomerEntity ToCustomerEntity() => new CustomerEntity(Id, Name);

    public static CustomerDatabaseEntity FromCustomerEntity(CustomerEntity customerEntity) =>
        new(customerEntity.Id, customerEntity.Name);
}
