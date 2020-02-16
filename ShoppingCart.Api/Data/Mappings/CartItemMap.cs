using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CartItemMap
    {
        public static ModelBuilder MapCartItem(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CartItem>();

            entity.ToTable("CartItem");
            entity.MapDomainBase();
            entity.Property(x => x.Product);
            entity.Property(x => x.Quantity);

            entity.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            return modelBuilder;
        }
    }
}