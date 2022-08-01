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
    public class BlogImageRepository : IBlogImageService
    {
        private readonly AppDbContext _context;
        public BlogImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogImage> GetForBlogId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.BlogImages.Where(n => n.BlogId == id)
                                                .Include(n => n.Image)
                                                .Include(n => n.Blog)
                                                .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<BlogImage> GetForImageId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.BlogImages.Where(n => n.ImageId == id)
                                                .Include(n => n.Image)
                                                .Include(n => n.Blog)
                                                .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Blog blog, List<Image> images)
        {
            List<BlogImage> blogImages = new List<BlogImage>();
            foreach (var image in images)
            {
                BlogImage blogImage = new BlogImage
                {
                    BlogId = blog.Id,
                    ImageId = image.Id,
                };
                blogImages.Add(blogImage);
            }
            blog.BlogImages = blogImages;
            await _context.SaveChangesAsync();
        }

        public async Task Update(Blog blog, Image image)
        {
            var data = await GetForBlogId(blog.Id);
            data.ImageId = image.Id;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMultiple(Blog blog, List<Image> images)
        {
            foreach (var image in images)
            {
                var data = await GetForImageId(image.Id);

                data.ImageId = image.Id;
            }

            await _context.SaveChangesAsync();
        }
    }
}
