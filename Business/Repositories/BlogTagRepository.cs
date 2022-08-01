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
    public class BlogTagRepository : IBlogTagService
    {
        private readonly AppDbContext _context;
        public BlogTagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogTag>> GetForTagId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.BlogTags.Where(n => n.TagId == id)
                                              .Include(n => n.Blog)
                                              .Include(n => n.Tag)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<BlogTag>> GetForBlogId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.BlogTags.Where(n => n.BlogId == id)
                                              .Include(n => n.Blog)
                                              .Include(n => n.Tag)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(List<BlogTag> blogTags)
        {
            await _context.AddRangeAsync(blogTags);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await GetForBlogId(id);
            _context.BlogTags.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
    }
}
