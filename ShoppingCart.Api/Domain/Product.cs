namespace ShoppingCart.Api.Domain
{
    public class Product : DomainBase
    {
        public int DefinitionId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        
        public virtual ProductDefinition Definition { get; set; }
    }
}