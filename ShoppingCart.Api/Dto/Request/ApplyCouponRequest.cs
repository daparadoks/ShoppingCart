namespace ShoppingCart.Api.Dto.Request
{
    public class ApplyCouponRequest
    {
        public int CartId { get; set; }
        public int CouponId { get; set; }
        public int UserId { get; set; }
    }
}