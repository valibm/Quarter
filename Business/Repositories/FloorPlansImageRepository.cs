using Business.Services;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class FloorPlansImageRepository : IFloorPlansImageService
    {
        private readonly AppDbContext _context;
        public FloorPlansImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(FloorPlan floorPlan, Image image)
        {
            FloorPlansImage floorPlansImage = new FloorPlansImage
            {
                ImageId = image.Id,
                FloorPlanId = floorPlan.Id
            };

            floorPlan.FloorPlansImage = floorPlansImage;
            await _context.SaveChangesAsync();
        }
    }
}
