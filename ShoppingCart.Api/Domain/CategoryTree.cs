namespace ShoppingCart.Api.Domain
{
    public class CategoryTree : DomainBase
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int Distance { get; set; }
        
        public virtual Category Parent { get; set; }
        public virtual Category Child { get; set; }
    }
}