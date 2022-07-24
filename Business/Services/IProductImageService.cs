using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductImageService
    {
        public Task<ProductImage> GetForProductId(int? id);
        public Task Create(Product product, List<Image> images);
    }
}
