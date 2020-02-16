using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Repositories
{
    public interface ICouponRepository: IRepository<Coupon>
    {
        
    }

    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        public CouponRepository(CartDbContext dbContext) : base(dbContext, dbContext.CouponDbSet)
        {
        }
    }
}