using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class ProductMap
    {
        public static ModelBuilder MapProduct(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();
            entity.ToTable("Product");
            entity.MapDomainBase();

            entity.HasOne(x => x.Definition).WithMany().HasForeignKey(x => x.DefinitionId);

            return modelBuilder;
        }
    }
}