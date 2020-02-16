namespace ShoppingCart.Api.Domain
{
    public class ProductDefinition: DomainBase
    {
        public ProductDefinition(string title, Category category)
        {
            Title = title;
            Category = category;
        }
        public string Title { get; }
        public Category Category { get; }
    }
}