using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Business.Services;
using Business.Repositories;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System;

namespace Quarter
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(_config.GetConnectionString("Default"));
            });

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<ISliderService, SliderRepository>();
            services.AddScoped<IImageService, ImageRepository>();
            services.AddScoped<ISliderImageService, SliderImageRepository>();
            services.AddScoped<IServiceImageService, ServiceImageRepository>();
            services.AddScoped<IServiceService, ServiceRepository>();
            services.AddScoped<IProductService, ProductRepository>();
            services.AddScoped<IAreaService, AreaRepository>();
            services.AddScoped<IProductStatusService, ProductStatusRepository>();
            services.AddScoped<IProductDetailsService, ProductDetailsRepository>();
            services.AddScoped<IProductFeatureService, ProductFeatureRepository>();
            services.AddScoped<IProductImageService, ProductImageRepository>();
            services.AddScoped<IAmenityService, AmenityRepository>();
            services.AddScoped<IFloorPlansImageService, FloorPlansImageRepository>();
            services.AddScoped<IFloorPlanService, FloorPlanRepository>();
            services.AddScoped<IFloorFeatureService, FloorFeatureRepository>();
            services.AddScoped<IProductSubCatagoryService, ProductSubCatagoryRepository>();
            services.AddScoped<IPropertyTypeService, PropertyTypeRepository>();
            services.AddScoped<IPositionService, PositionRepository>();
            services.AddScoped<ICatagoryService, CatagoryRepository>();
            services.AddScoped<ISubCatagoryService, SubCatagoryRepository>();
            services.AddScoped<ILocationService, LocationRepository>();
            services.AddScoped<IBlogService, BlogRepository>();
            services.AddScoped<IBlogImageService, BlogImageRepository>();
            services.AddScoped<ITagService, TagRepository>();
            services.AddScoped<IBlogTagService, BlogTagRepository>();
            services.AddScoped<ICommentService, CommentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "Admin",
                    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                );

                endpoints.MapControllerRoute
                (
                    name: "Default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                );
            });
        }
    }
}
