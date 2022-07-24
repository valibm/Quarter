using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductFeatureService
    {
        public Task<ProductFeature> Get(int? id);
        public Task<List<ProductFeature>> GetAll();
        public Task Create(ProductFeature productFeature);
    }
}
