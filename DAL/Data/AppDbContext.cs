using DAL.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<SubCatagory> SubCatagories { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<FloorPlansImage> FloorPlansImages { get; set; }
        public DbSet<FloorFeature> FloorFeatures { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductSubCatagory> ProductSubCatagories { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceImage> ServiceImages { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserSocials> UserSocials { get; set; }
    }
}
