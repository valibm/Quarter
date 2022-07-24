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
    public class ProductDetailsRepository : IProductDetailsService
    {
        private readonly AppDbContext _context;
        public ProductDetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDetails> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ProductDetails.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<ProductDetails>> GetAll()
        {
            var data = await _context.ProductDetails.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(ProductDetails productDetails)
        {
            await _context.ProductDetails.AddAsync(productDetails);
            await _context.SaveChangesAsync();
        }
    }
}
