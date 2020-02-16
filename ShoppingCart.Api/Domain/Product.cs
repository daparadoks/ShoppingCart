namespace ShoppingCart.Api.Domain
{
    public class Product : DomainBase
    {
        public Product(int id)
        {
            Id = id;
        }
        
        public Product(ProductDefinition definition, double price, int stock)
        {
            Definition = definition;
            Price = price;
            Stock = stock;
        }
        public ProductDefinition Definition { get; }
        public double Price { get; }
        public int Stock { get; }
    }
}