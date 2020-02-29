using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : DomainBase
    {
        private readonly DbContext _dbContext;

        protected virtual DbSet<T> DbSet => _dbContext.Set<T>();
        protected virtual IQueryable<T> DbSetNoTracking => DbSet.AsNoTracking();

        public IQueryable<T> BaseQuery => DbSet.Where(x => !x.IsDeleted);
        public IQueryable<T> BaseQueryNoTracking => DbSetNoTracking.Where(x => !x.IsDeleted);

        protected Repository(DbContext dbContext) => _dbContext = dbContext;
        
        public async Task Add(T entity)
        {
            entity.IsDeleted = false;
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        
        public async Task Delete(T entity)
        {
            entity.IsDeleted = true;
            DbSet.Update(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> FindById(int id) => await BaseQuery.FirstOrDefaultAsync(x => x.Id == id);
    }
}