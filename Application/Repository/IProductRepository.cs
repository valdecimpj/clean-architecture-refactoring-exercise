using Domain.Entity;

namespace Application.Repository;

public interface IProductRepository
{
    Task Save(ProductEntity product);
}