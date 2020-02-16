namespace ShoppingCart.Api.Domain
{
    public class Category : DomainBase
    {
        public Category(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}