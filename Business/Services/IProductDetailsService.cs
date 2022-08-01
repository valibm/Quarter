using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductDetailsService
    {
        public Task<ProductDetails> Get(int? id);
        public Task<List<ProductDetails>> GetAll();
        public Task Create(ProductDetails productDetails);
        public Task Update(int id, ProductDetails productDetails);
    }
}
