using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductStatusService
    {
        public Task<ProductStatus> Get(int? id);
        public Task<List<ProductStatus>> GetAll();
    }
}
