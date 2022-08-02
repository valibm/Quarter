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
    public class CommentRepository : ICommentService
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetForManaging(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _context.Comments.Where(c => c.Id == id)
                                              .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Comment>> GetForManagingAll()
        {
            var data = await _context.Comments.Where(c => !c.IsAllowed)
                                              .Include(c => c.AppUser)
                                              .ThenInclude(c => c.Image)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Comment>> GetForBlog(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _context.Comments.Where(c => c.BlogId == id)
                                              .Include(c => c.AppUser)
                                              .ThenInclude(c => c.Image)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Comment>> GetForProduct(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _context.Comments.Where(c => c.ProductId == id)
                                              .Include(c => c.AppUser)
                                              .ThenInclude(c => c.Image)
                                              .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Comment comment)
        {
            comment.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Allow(int? id)
        {
            var comment = await GetForManaging(id);
            comment.IsAllowed = true;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var comment = await GetForManaging(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
