using System.Threading.Tasks;
using ShoppingCart.Api.Domain;
using ShoppingCart.Api.Repositories;

namespace ShoppingCart.Api.Services
{
    public class CouponService : Service, ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<Coupon> Get(int id) => await _couponRepository.FindById(id);
    }
}