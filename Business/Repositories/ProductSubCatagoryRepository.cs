using Business.Services;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ProductSubCatagoryRepository : IProductSubCatagoryService
    { 
        private readonly AppDbContext _context;
        public ProductSubCatagoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ProductSubCatagory productSubCatagory)
        {
            await _context.ProductSubCatagories.AddAsync(productSubCatagory);
            await _context.SaveChangesAsync();
        }
    }
}
