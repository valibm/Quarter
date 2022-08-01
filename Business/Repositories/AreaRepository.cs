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

        public async Task<List<Area>> GetForHome()
        {
            var data = await _context.Areas.Include(a => a.Location)
                                           .Include(a => a.Products)
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<Area> GetForArea(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Areas.Where(a => a.Id == id)
                                           .Include(a => a.Location)
                                           .Include(a => a.Products)
                                           .ThenInclude(a => a.ProductDetails)
                                           .Include(a => a.Products)
                                           .ThenInclude(a => a.ProductImages)
                                           .ThenInclude(a => a.Image)
                                           .Include(a => a.Products)
                                           .ThenInclude(a => a.Area)
                                           .ThenInclude(a => a.Location)
                                           .Include(a => a.Products)
                                           .ThenInclude(a => a.ProductStatus)
                                           .Include(a => a.Products)
                                           .ThenInclude(a => a.AppUser)
                                           .ThenInclude(a => a.Image)
                                           .FirstOrDefaultAsync();

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

        public async Task Update(int id, Area entity)
        {
            var data = await Get(id);
            data.Name = entity.Name;
            data.LocationId = entity.LocationId;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            _context.Areas.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
