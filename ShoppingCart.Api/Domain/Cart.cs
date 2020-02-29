using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Api.Domain
{
    public class Cart : DomainBase
    {
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal CouponAmount { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal AmountToBePaid { get; set; }
        public decimal DiscountTotal { get; set; }
        public List<Campaign> AppliedCampaign { get; set; }
        public List<Coupon> AppliedCoupon { get; set; }
    }
}