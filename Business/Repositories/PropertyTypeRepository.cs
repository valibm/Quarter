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
    public class PropertyTypeRepository : IPropertyTypeService
    {
        private readonly AppDbContext _context;
        public PropertyTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubCatagory> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.SubCatagories.Where(n => n.Id == id && n.Catagory.Name.ToUpper() == "PROPERTY TYPE")
                                                   .Include(n => n.Catagory)
                                                   .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<SubCatagory>> GetAll()
        {
            var data = await _context.SubCatagories.Where(n => n.Catagory.Name.ToUpper() == "PROPERTY TYPE")
                                                   .Include(n => n.Catagory)
                                                   .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }
    }
}
