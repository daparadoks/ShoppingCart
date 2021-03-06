using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly CartDbContext _dbContext;

        public CartRepository(CartDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> FindByUserId(int userId) => BaseQueryNoTracking.FirstOrDefault(x => x.UserId == userId)?.Id;
    }
}