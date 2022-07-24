using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ServiceImage> GetForServiceId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.ServiceImages.Where(n => n.ServiceId == id)
                                                   .Include(n => n.Image)
                                                   .Include(n => n.Service)
                                                   .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
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

        public async Task Update(Service service, Image image)
        {
            var data = await GetForServiceId(service.Id);
            data.ImageId = image.Id;
            await _context.SaveChangesAsync();
        }
    }
}
