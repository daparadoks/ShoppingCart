using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Dto.Response;

namespace ShoppingCart.Api.Contexts
{
    public interface ICartContext
    {
        Task<Cart> Get();
        Task<int?> GetId();
        Task AddItem(int productId, int quantity);
        Task RemoveItem(int productId);
        Task UpdateItem(int productId, int quantity);
        Task<bool> ApplyCoupon(int couponId);
        Task<Cart> ApplyCampaign();
        Task<Cart> CalculateDeliveryCost();
    }
}