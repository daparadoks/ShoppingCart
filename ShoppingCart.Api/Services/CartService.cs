using System.Threading.Tasks;
using ShoppingCart.Api.Constants;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Repositories;
using ShoppingCart.Api.Repositories.Redis;

namespace ShoppingCart.Api.Services
{
    public class CartService : Service, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IRedisClient _redisClient;

        public CartService(ICartRepository cartRepository, IRedisClient redisClient)
        {
            _cartRepository = cartRepository;
            _redisClient = redisClient;
        }

        public async Task<Cart> Get(int id) => await _cartRepository.FindById(id);
        
        public async Task<Cart> Add(int userId)
        {
            var cart = new Cart(userId);
            await _cartRepository.Add(cart);
            return cart;
        }

        public async Task<Cart> GetOrAddCart(int? cartId, int userId) =>
            cartId.HasValue ? await Get(cartId.Value) : await Add(userId);

        public async Task AddItem(Cart cart, Product product, int quantity)
        {
            var cartItem = new CartItem(product, quantity);
            cart.Items.Add(cartItem);
            await _cartRepository.Update(cart);
        }

        public Task Update(Cart cart) => _cartRepository.Update(cart);

        public async Task<int?> GetIdByUserId(int userId) =>
            await _redisClient.GetAndSet<int?>(AppConstants.CartId(userId), _cartRepository.FindByUserId(userId));
    }
}