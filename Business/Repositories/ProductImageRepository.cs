using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ProductImageRepository : IProductImageService
    {
        private readonly AppDbContext _context;
        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductImage> GetForProductId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ProductImages.Where(n => n.ProductId == id)
                                                   .Include(n => n.Image)
                                                   .Include(n => n.Product)
                                                   .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Product product, List<Image> images)
        {
            List<ProductImage> productImages = new List<ProductImage>();
            foreach (var image in images)
            {
                ProductImage productImage = new ProductImage
                {
                    ProductId = product.Id,
                    ImageId = image.Id,
                };
                productImages.Add(productImage);
            }
            await _context.ProductImages.AddRangeAsync(productImages);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product, Image image)
        {
            var data = await GetForProductId(product.Id);
            data.ImageId = image.Id;
            await _context.SaveChangesAsync();
        }
    }
}
