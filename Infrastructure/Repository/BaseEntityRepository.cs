using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public abstract class BaseEntityRepository<TEntity>(DirtyStoreDbContext dbContext)
        where TEntity : class
    {
        protected readonly DirtyStoreDbContext dbContext = dbContext;

        public async Task<TEntity> Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
