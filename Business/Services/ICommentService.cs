using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICommentService
    {
        public Task Create(Comment comment);
        public Task<List<Comment>> GetForManagingAll();
        public Task<Comment> GetForManaging(int? id);
        public Task<List<Comment>> GetForBlog(int? id);
        public Task<List<Comment>> GetForProduct(int? id);
        public Task Delete(int? id);
        public Task Allow(int? id);
    }
}
