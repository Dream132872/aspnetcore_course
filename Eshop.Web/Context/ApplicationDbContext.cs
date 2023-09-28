using Eshop.Web.Entities.Account;
using Eshop.Web.Entities.Catalog;
using Eshop.Web.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
    }
}