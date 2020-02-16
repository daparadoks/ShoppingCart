using System.Threading.Tasks;
using ShoppingCart.Api.Dto.Request;
using ShoppingCart.Api.Dto.Response;

namespace ShoppingCart.Api.Facades
{
    public interface ICartFacade: IFacade
    {
        Task<bool> AddItem(UpdateCartItemRequest itemRequest);
        Task<bool> UpdateItem(UpdateCartItemRequest itemRequest);
        Task<bool> ApplyCoupon(ApplyCouponRequest request);
        Task<CartResponse> ApplyCampaign();
        Task<CartResponse> CalculateDeliveryCost();
    }
}