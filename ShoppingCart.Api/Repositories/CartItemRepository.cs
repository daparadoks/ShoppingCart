using ShoppingCart.Api.Data;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public class CartItemRepository: Repository<CartItem>, ICartItemRepository
    {
        private readonly CartDbContext _dbContext;

        public CartItemRepository(CartDbContext dbContext) : base(dbContext, dbContext.CartItemDbSet)
        {
            _dbContext = dbContext;
        }
    }
}