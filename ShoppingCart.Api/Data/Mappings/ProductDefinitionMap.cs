using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class ProductDefinitionMap
    {
        public static ModelBuilder MapProductDefinition(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductDefinition>();
            entity.ToTable("ProductDefinition");
            entity.MapDomainBase();

            return modelBuilder;
        }
    }
}