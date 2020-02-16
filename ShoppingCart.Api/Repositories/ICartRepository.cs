using System.Threading.Tasks;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public interface ICartRepository: IRepository<Cart>
    {
        Task<int?> FindByUserId(int userId);
    }
}