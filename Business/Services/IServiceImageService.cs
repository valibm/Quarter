using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IServiceImageService
    {
        public Task Create(Service service, List<Image> images);
    }
}
