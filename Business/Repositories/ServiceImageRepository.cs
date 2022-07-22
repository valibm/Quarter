using Business.Services;
using DAL.Data;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class ServiceImageRepository : IServiceImageService
    {
        private readonly AppDbContext _context;
        public ServiceImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Service service, List<Image> images)
        {
            List<ServiceImage> serviceImages = new List<ServiceImage>();
            foreach (var image in images)
            {
                ServiceImage serviceImage = new ServiceImage
                {
                    ServiceId = service.Id,
                    ImageId = image.Id,
                };
                serviceImages.Add(serviceImage);
            }
            service.ServiceImages = serviceImages;
            await _context.SaveChangesAsync();
        }
    }
}
