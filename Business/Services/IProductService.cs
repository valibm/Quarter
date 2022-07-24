using Business.Base;
using Business.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductService
    {
        public Task<Product> Get(int? id);
        public Task<List<Product>> GetAll();
        public Task<Product> Create(ProductVM productVM, ProductDetails productDetails);
    }
}
