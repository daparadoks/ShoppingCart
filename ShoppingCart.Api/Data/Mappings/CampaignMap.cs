using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data.Mappings
{
    public static class CampaignMap
    {
        public static ModelBuilder MapCampaign(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Campaign>();
            entity.ToTable("Campaign");
            entity.MapDiscountBase();
            entity.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            return modelBuilder;
        }
    }
}