using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Data.Mappings;
using ShoppingCart.Api.Domain;

namespace ShoppingCart.Api.Data
{
    public class CartDbContext:DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options):base(options)
        {
            
        }

        public DbSet<Campaign> CampaignDbSet { get; set; }
        public DbSet<Cart> CartDbSet { get; set; }
        public DbSet<CartItem> CartItemDbSet { get; set; }
        public DbSet<Category> CategoryDbSet { get; set; }
        public DbSet<Coupon> CouponDbSet { get; set; }
        public DbSet<Product> ProductDbSet { get; set; }
        public DbSet<ProductDefinition> ProductDefinitionDbSet { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapCampaign();
            modelBuilder.MapCart();
            modelBuilder.MapCartItem();
            modelBuilder.MapCategory();
            modelBuilder.MapCoupon();
            modelBuilder.MapProduct();
            modelBuilder.MapProductDefinition();
        }
    }
}