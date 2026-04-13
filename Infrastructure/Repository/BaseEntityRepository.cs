using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public abstract class BaseEntityRepository<TEntity>(DirtyStoreDbContext dbContext)
        where TEntity : class
    {
        protected readonly DirtyStoreDbContext dbContext = dbContext;

        public async Task<TEntity> Save(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
                dbContext.Set<TEntity>().Add(entity);
            else
                dbContext.Set<TEntity>().Update(entity);

            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
