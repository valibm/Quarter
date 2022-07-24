using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServiceImageService
    {
        public Task<ServiceImage> GetForServiceId(int? id);
        public Task Create(Service service, List<Image> images);
        public Task Update(Service service, Image image);
    }
}
