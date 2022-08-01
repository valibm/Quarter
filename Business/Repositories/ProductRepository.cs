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
                                              .Include(n => n.ProductFeature)
                                              .Include(n => n.ProductDetails)
                                              .Include(n => n.Area)
                                              .ThenInclude(n => n.Location)
                                              .Include(p => p.ProductStatus)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.FloorPlans)
                                              .ThenInclude(p => p.FloorPlansImage)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.ProductSubCatagories)
                                              .ThenInclude(p => p.SubCatagory)
                                              .ThenInclude(p => p.Catagory)
                                              .Include(p => p.AppUser)
                                              .ThenInclude(p => p.Image)
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
                                              .Include(n => n.ProductFeature)
                                              .Include(n => n.ProductDetails)
                                              .Include(n => n.Area)
                                              .ThenInclude(n => n.Location)
                                              .Include(p => p.ProductStatus)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.FloorPlans)
                                              .ThenInclude(p => p.FloorPlansImage)
                                              .ThenInclude(p => p.Image)
                                              .Include(p => p.ProductSubCatagories)
                                              .ThenInclude(p => p.SubCatagory)
                                              .ThenInclude(p => p.Catagory)
                                              .Include(p => p.AppUser)
                                              .ThenInclude(p => p.Image)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Product>> GetForHome()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                              .Include(n => n.ProductDetails)
                                              .Include(p => p.ProductStatus)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .Include(n => n.Area)
                                              .ThenInclude(n => n.Location)
                                              .Include(p => p.AppUser)
                                              .ThenInclude(p => p.Image)
                                              .Take(6)
                                              .OrderByDescending(n => n.CreatedDate)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Product>> GetAllForIndex()
        {
            var data = await _context.Products.Where(n => !n.IsDeleted)
                                              .Include(n => n.ProductImages)
                                              .ThenInclude(n => n.Image).ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<Product> GetForDetails(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Products.Where(n => !n.IsDeleted && n.Id == id)
                                              .Include(p => p.ProductImages)
                                              .ThenInclude(p => p.Image)
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<Product> Create(ProductVM productVM, int productDetailsId, int ProductFeatureId)
        {
            Product product = new Product
            {
                Title = productVM.Title,
                Description = productVM.Description,
                SubDescription = productVM.SubDescription,
                VideoLink = productVM.VideoLink,
                AreaId = productVM.AreaId,
                ProductStatusId = productVM.ProductStatusId,
                ProductDetailsId = productDetailsId,
                ProductFeatureId = ProductFeatureId,
                AppUserId = productVM.AppUserId
            };

            product.CreatedDate = DateTime.UtcNow.AddHours(4);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Update(int id, Product entity)
        {
            var data = await Get(id);
            data.Title = entity.Title;
            data.Description = entity.Description;
            data.SubDescription = entity.SubDescription;
            data.VideoLink = entity.VideoLink;
            data.AreaId = entity.AreaId;
            data.ProductStatusId = entity.ProductStatusId;
            entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

    }
}
