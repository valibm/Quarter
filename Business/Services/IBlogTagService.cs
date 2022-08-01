using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBlogTagService
    {
        public Task Create(List<BlogTag> blogTags);
        public Task<List<BlogTag>> GetForTagId(int? id);
        public Task<List<BlogTag>> GetForBlogId(int? id);
        public Task Remove(int id);
    }
}
