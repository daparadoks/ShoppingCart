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
        private readonly DbSet<T> _dbSet;

        public IQueryable<T> BaseQuery => _dbSet.Where(x => !x.IsDeleted);

        public Repository(DbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = _dbContext;
            _dbSet = dbSet;
        }
        
        public async Task Add(T entity)
        {
            ValidateEntity(entity);

            entity.IsDeleted = false;
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Update(T entity)
        {
            ValidateEntity(entity);

            _dbSet.Update(entity);
            await SaveChanges();
        }
        
        public async Task Delete(T entity)
        {
            ValidateEntity(entity);

            entity.IsDeleted = true;
            _dbSet.Update(entity);
            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> FindById(int id) => await BaseQuery.FirstOrDefaultAsync(x => x.Id == id);
        
        private static void ValidateEntity(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
        }
    }
}