using Business.Services;
using Business.ViewModels;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ProductRepository : IProductService
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Products.Where(n => !n.IsDeleted && n.Id == id)
                                              .Include(n => n.ProductFeatures)
                                              .Include(n => n.ProductDetails)
                                              .Include(n => n.Area)
                                              .ThenInclude(n => n.Location)
                                              .Include(p => p.ProductStatus)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .Include(n => n.FloorPlans)
                                              .ThenInclude(n => n.FloorFeatures)
                                              .Include(p => p.FloorPlans)
                                              .ThenInclude(p => p.FloorPlansImage)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.ProductSubCatagories)
                                              .ThenInclude(p => p.SubCatagory)
                                              .ThenInclude(p => p.Catagory)
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Product>> GetAll()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                              .Include(n => n.ProductFeatures)
                                              .Include(n => n.ProductDetails)
                                              .Include(n => n.Area)
                                              .ThenInclude(n => n.Location)
                                              .Include(p => p.ProductStatus)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .Include(n => n.FloorPlans)
                                              .ThenInclude(n => n.FloorFeatures)
                                              .Include(p => p.FloorPlans)
                                              .ThenInclude(p => p.FloorPlansImage)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.ProductSubCatagories)
                                              .ThenInclude(p => p.SubCatagory)
                                              .ThenInclude(p => p.Catagory)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<Product> Create(ProductVM productVM, ProductDetails productDetails)
        {
            Product product = new Product
            {
                Title = productVM.Title,
                Description = productVM.Description,
                SubDescription = productVM.SubDescription,
                VideoLink = productVM.VideoLink,
                AreaId = productVM.AreaId,
                ProductStatusId = productVM.ProductStatusId,
                ProductDetailsId = productDetails.Id,
            };

            product.CreatedDate = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        //public async Task Update(int id, Product entity)
        //{
        //    var data = await Get(id);
        //    data.Title = entity.Title;
        //    data.Description = entity.Description;
        //    data.SubDescription = entity.SubDescription;
        //    data.VideoLink = entity.VideoLink;
        //    data.Images = entity.Images;
        //    data.AreaId = entity.AreaId;
        //    data.ProductDetailsId = entity.ProductDetailsId;
        //    data.ProductFeatures = entity.ProductFeatures;
        //    data.Area.LocationId = data.Area.LocationId;
        //    data.FloorPlans = entity.FloorPlans;
        //    entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Delete(int? id)
        //{
        //    var entity = await Get(id);
        //    entity.IsDeleted = true;
        //    await _context.SaveChangesAsync();
        //}
    }
}
