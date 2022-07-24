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
    public class ProductStatusRepository : IProductStatusService
    {
        private readonly AppDbContext _context;
        public ProductStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductStatus> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ProductStatuses.Where(n => n.Id == id)
                                                     .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<ProductStatus>> GetAll()
        {
            var data = await _context.ProductStatuses.ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }
    }
}
