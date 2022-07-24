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
    public class SliderRepository : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Slider> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Sliders.Where(s => !s.IsDeleted && s.Id == id)
                                             .Include(n => n.SliderImage)
                                             .ThenInclude(n => n.Image)
                                             .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Slider>> GetAll()
        {
            var data = await _context.Sliders.Where(s => !s.IsDeleted)
                                             .Include(n => n.SliderImage)
                                             .ThenInclude(n => n.Image)
                                             .OrderByDescending(s => s.CreatedDate)
                                             .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Slider entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Sliders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Slider entity)
        {
            var data = await Get(id);
            data.Title = entity.Title;
            data.SubTitle = entity.SubTitle;
            data.Content = entity.Content;
            data.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            _context.Sliders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
