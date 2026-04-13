using Application.Repository;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ProductRepository(DirtyStoreDbContext dbContext)
    : BaseEntityRepository<ProductDatabaseEntity>(dbContext),
        IProductRepository
{
    public async Task<IEnumerable<ProductEntity>> GetByCodes(
        IEnumerable<string> codes,
        bool throwIfNotFound = false
    )
    {
        var products = await dbContext.Products.Where(p => codes.Contains(p.Code)).ToListAsync();

        if (throwIfNotFound && products.Count != codes.Count())
        {
            var foundCodes = products.Select(_ => _.Code);
            var notFoundCodes = codes.Except(foundCodes);
            throw new ArgumentException(
                $"Products with codes {string.Join(", ", notFoundCodes)} not found."
            );
        }

        return products.Select(p => p.ToProductEntity());
    }

    public async Task Save(ProductEntity product) =>
        await Save(ProductDatabaseEntity.FromProductEntity(product));
}
