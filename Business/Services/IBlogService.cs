using Business.Base;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBlogService : IBaseService<Blog>
    {
        public bool ContainsTag(Blog blog, Tag tag);
        public Task<List<Blog>> GetForWidget(Blog blog);
        public Task<List<Blog>> GetRelated(List<BlogTag> blogtags);
        public Task<List<Blog>> GetForHome();
    }
}
