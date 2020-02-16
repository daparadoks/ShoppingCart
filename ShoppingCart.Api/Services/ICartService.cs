using System.Threading.Tasks;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Services
{
    public interface ICartService : IService
    {
        Task<Cart> Get(int id);
        Task<Cart> Add(int userId);
        Task<Cart> GetOrAddCart(int? cartId, int userId);
        Task AddItem(Cart cart, Product product, int quantity);
        Task Update(Cart cart);
        Task<int?> GetIdByUserId(int userId);
    }
}