using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class DomainBaseMap
    {
        public static EntityTypeBuilder<T> MapDomainBase<T>(this EntityTypeBuilder<T> entity) where T : DomainBase
        {
            entity.HasKey(s => s.Id);
            return entity;
        }
    }
    
    public static class DiscountBaseMap
    {
        public static EntityTypeBuilder<T> MapDiscountBase<T>(this EntityTypeBuilder<T> entity) where T : DiscountBase
        {
            entity.MapDomainBase();
            entity.Property(x => x.Discount).IsRequired();
            entity.Property(x => x.DiscountTypeId).IsRequired();
            entity.Ignore(x => x.DiscountType);
            return entity;
        }
    }
}