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
    public class ServiceRepository : IServiceService
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Service> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Services.Where(n => !n.IsDeleted && n.Id == id)
                                              .Include(n => n.Images)
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Service>> GetAll()
        {
            var data = await _context.Services.Where(s => !s.IsDeleted)
                                              .Include(s => s.Images)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Service entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Service entity)
        {
            var data = await Get(id);
            data.Title = entity.Title;
            data.Description = entity.Description;
            data.Content = entity.Content;
            data.Images = entity.Images;
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
