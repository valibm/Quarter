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
    public class BlogRepository : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Blogs.Where(n => n.Id == id && !n.IsDeleted)
                                           .Include(n => n.AppUser)
                                           .ThenInclude(n => n.Image)
                                           .Include(n => n.BlogImages)
                                           .ThenInclude(n => n.Image)
                                           .Include(n => n.BlogTags)
                                           .ThenInclude(n => n.Tag)
                                           .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Blog>> GetAll()
        {
            var data = await _context.Blogs.Where(n => !n.IsDeleted)
                                           .Include(n => n.BlogImages)
                                           .ThenInclude(n => n.Image)
                                           .Include(n => n.BlogTags)
                                           .ThenInclude(n => n.Tag)
                                           .Include(n => n.AppUser)
                                           .ThenInclude(n => n.Image)
                                           .Include(n => n.Comments)
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Blog>> GetForHome()
        {
            var data = await _context.Blogs.Where(n => !n.IsDeleted)
                                           .Include(n => n.BlogImages)
                                           .ThenInclude(n => n.Image)
                                           .Include(n => n.BlogTags)
                                           .ThenInclude(n => n.Tag)
                                           .Include(n => n.AppUser)
                                           .ThenInclude(n => n.Image)
                                           .Take(6)
                                           .OrderByDescending(n => n.CreatedDate)
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Blog>> GetForWidget(Blog blog)
        {
            var data = await _context.Blogs.Where(n => !n.IsDeleted && !(n.Id == blog.Id))
                                           .Include(n => n.BlogImages)
                                           .ThenInclude(n => n.Image)
                                           .Take(4)
                                           .OrderByDescending(n => n.CreatedDate)
                                           .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Blog>> GetRelated(List<BlogTag> blogtags)
        {
            List<Blog> blogs = new List<Blog>();
            foreach (var blogTag in blogtags)
            {
                var newBlogTags = await _context.BlogTags.Where(n => n.TagId == blogTag.TagId && !(n.BlogId == blogTag.BlogId))
                                                        .ToListAsync();

                foreach (var newBlogTag in newBlogTags)
                {
                    var newBlog = await _context.Blogs.Where(n => n.Id == newBlogTag.BlogId && !(n.Id == blogTag.BlogId))
                                                      .Include(n => n.BlogImages)
                                                      .ThenInclude(n => n.Image)
                                                      .FirstOrDefaultAsync();
                    if (blogs.Count == 0)
                    {
                        blogs.Add(newBlog);
                    }
                    else
                    {
                        foreach (var blog in blogs)
                        {
                            if (blog.Id == newBlog.Id)
                            {
                                break;
                            }
                            else
                            {
                                blogs.Add(newBlog);
                                break;
                            }
                        }
                    }
                }
            }


            return blogs;
        }

        public async Task Create(Blog blog)
        {
            blog.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Blog entity)
        {
            var data = await Get(id);
            data.Title = entity.Title;
            data.Content = entity.Content;
            data.Description = entity.Description;
            data.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public bool ContainsTag(Blog blog, Tag tag)
        {
            foreach (var blogTag in blog.BlogTags)
            {
                if (blogTag.Tag.Id == tag.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
