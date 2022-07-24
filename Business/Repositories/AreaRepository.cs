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
    public class AreaRepository : IAreaService
    {
        private readonly AppDbContext _context;
        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Area> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Areas.Where(a => a.Id == id)
                                           .Include(a => a.Location)
                                           .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Area>> GetAll()
        {
            var data = await _context.Areas.Include(a => a.Location)
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Area area)
        {
            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }
    }
}
