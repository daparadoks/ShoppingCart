namespace ShoppingCart.Api.Domain
{
    public class CartItem : DomainBase
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}