namespace ShoppingCart.Api.Domain
{
    public class Campaign : DiscountBase
    {
        public Category Category { get; set; }
        public int MinimumItem { get; set; }
        public int CategoryId { get; set; }
    }
}