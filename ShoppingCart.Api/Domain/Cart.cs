using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Api.Domain
{
    public class Cart : DomainBase
    {
        public Cart(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double CouponAmount { get; set; }
        public double DeliveryCost { get; set; }
        public double AmountToBePaid { get; set; }
        public double DiscountTotal { get; set; }
        public List<Campaign> AppliedCampaign { get; set; }
        public List<Coupon> AppliedCoupon { get; set; }
    }
}