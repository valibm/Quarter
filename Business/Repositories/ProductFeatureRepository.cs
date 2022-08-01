using Business.Services;
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
    public class ProductFeatureRepository : IProductFeatureService
    {
        private readonly AppDbContext _context;
        public ProductFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductFeature> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ProductFeatures.Where(n => n.Id == id)
                                                     .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<ProductFeature>> GetAll()
        {
            var data = await _context.ProductFeatures.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(ProductFeature productFeature)
        {
            await _context.ProductFeatures.AddAsync(productFeature);
            await _context.SaveChangesAsync();
        }
    }
}
