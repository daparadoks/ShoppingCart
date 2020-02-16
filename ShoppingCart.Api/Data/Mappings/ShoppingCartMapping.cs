using System;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CartMap
    {
        public static ModelBuilder MapCart(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Cart>();
            entity.ToTable("ShoppingCart");
            entity.MapDomainBase();
            entity.Property(x => x.Discount).IsRequired();
            entity.Property(x => x.CouponAmount).IsRequired();
            entity.Property(x => x.DeliveryCost).IsRequired();
            entity.Property(x => x.DiscountTotal).IsRequired();
            entity.Property(x => x.TotalPrice).IsRequired();
            entity.Property(x => x.AmountToBePaid).IsRequired();

            entity.HasMany(x => x.AppliedCampaign).WithOne().HasForeignKey(x => x.Id);
            entity.HasMany(x => x.AppliedCoupon).WithOne().HasForeignKey(x => x.Id);

            return modelBuilder;
        }
    }
}