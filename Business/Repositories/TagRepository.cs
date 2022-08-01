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
    public class TagRepository : ITagService
    {
        private readonly AppDbContext _context;
        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Tags.Where(a => a.Id == id)
                                          .Include(a => a.BlogTags)
                                          .ThenInclude(a => a.Blog)
                                          .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Tag>> GetAll()
        {
            var data = await _context.Tags.Include(a => a.BlogTags)
                                          .ThenInclude(a => a.Blog)
                                          .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Tag>> GetForWidget()
        {
            var data = await _context.Tags.Include(a => a.BlogTags)
                                          .ThenInclude(a => a.Blog)
                                          .Take(10)
                                          .OrderByDescending(a => a.CreatedDate)
                                          .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Tag tag)
        {
            tag.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Tag entity)
        {
            var data = await Get(id);
            data.Name = entity.Name;
            data.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            _context.Tags.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
