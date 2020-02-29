namespace ShoppingCart.Api.Domain
{
    public class Coupon : DiscountBase
    {
        public decimal MinimumAmount { get; set; }
    }
}