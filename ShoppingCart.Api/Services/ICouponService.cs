using System.Threading.Tasks;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Services
{
    public interface ICouponService : IService
    {
        Task<Coupon> Get(int id);
    }
}