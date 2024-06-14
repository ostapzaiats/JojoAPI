using JojoAPI.Core.Interfaces;
using JojoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace JojoAPI.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext context;
        public DbSet<T> dbSet;
        protected readonly ILogger logger;

        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }
        
        public async Task<bool> Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null) context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

    }
}
