namespace Domain.Entity;

public class ProductDatabaseEntity(string code, string name, decimal currentPrice)
{
    public string Code { get; set; } = code;
    public string Name { get; set; } = name;
    public decimal CurrentPrice { get; set; } = currentPrice;

    public ProductEntity ToProductEntity() => new ProductEntity(Code, Name, CurrentPrice);

    public static ProductDatabaseEntity FromProductEntity(ProductEntity productEntity) =>
        new(productEntity.Code, productEntity.Name, productEntity.CurrentPrice);
}
