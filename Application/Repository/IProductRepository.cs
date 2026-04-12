using Domain.Entity;

namespace Application.Repository;

public interface IProductRepository
{
    Task Save(ProductEntity product);
    Task<IEnumerable<ProductEntity>> GetByCodes(
        IEnumerable<string> codes,
        bool throwIfNotFound = false
    );
}
