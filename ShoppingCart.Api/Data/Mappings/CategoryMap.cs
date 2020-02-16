using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CategoryMap
    {
        public static ModelBuilder MapCategory(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Category>();
            entity.ToTable("Category");
            entity.MapDomainBase();

            return modelBuilder;
        }
    }
}