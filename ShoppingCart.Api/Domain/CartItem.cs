namespace ShoppingCart.Api.Domain
{
    public class CartItem : DomainBase
    {
        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}