using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CartDbContext dbContext, DbSet<Category> dbSet) : base(dbContext, dbSet)
        {
            
        }
    }
}