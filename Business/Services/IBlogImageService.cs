using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBlogImageService
    {
        public Task<BlogImage> GetForBlogId(int? id);
        public Task Create(Blog blog, List<Image> images);
        public Task Update(Blog blog, Image image);
        public Task UpdateMultiple(Blog blog, List<Image> images);
    }
}
