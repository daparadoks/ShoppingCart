using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CouponMap
    {
        public static ModelBuilder MapCoupon(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Coupon>();
            entity.ToTable("Coupon");
            entity.MapDiscountBase();

            return modelBuilder;
        }
    }
}