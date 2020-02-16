namespace ShoppingCart.Api.Domain
{
    public class DiscountBase : DomainBase
    {
        protected DiscountBase(double discount, DiscountType type)
        {
            Discount = discount;
            DiscountType = type;
        }

        public double Discount { get; }
        public DiscountType DiscountType { get; }
    }
}