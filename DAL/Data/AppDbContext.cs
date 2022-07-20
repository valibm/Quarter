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

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<SubCatagory> SubCatagories { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<FloorFeature> FloorFeatures { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<Service> Services { get; set; }
    }
}
