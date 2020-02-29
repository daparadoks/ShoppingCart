namespace ShoppingCart.Api.Domain
{
    public class DiscountBase : DomainBase
    {
        public decimal Discount { get; set; }
        public int DiscountTypeId { get; set; }
        public DiscountType DiscountType => (DiscountType) DiscountTypeId;
    }
}