namespace ShoppingCart.Api.Domain
{
    public class ProductDefinition: DomainBase
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}