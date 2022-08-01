using Business.Base;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ITagService : IBaseService<Tag>
    {
        public Task<List<Tag>> GetForWidget();
    }
}
