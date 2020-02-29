using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CategoryTreeMap
    {
        public static ModelBuilder MapCategoryTree(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CategoryTree>();
            entity.ToTable("CategoryTree");
            entity.MapDomainBase();

            entity.HasOne(x => x.Child).WithMany().HasForeignKey(x => x.ChildId);
            entity.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);

            return modelBuilder;
        }
    }
}