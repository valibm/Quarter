using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class SliderImageRepository : ISliderImageService
    {
        private readonly AppDbContext _context;
        public SliderImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SliderImage> GetForSliderId(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.SliderImages.Where(n => n.SliderId == id)
                                                  .Include(n => n.Image)
                                                  .Include(n => n.Slider)
                                                  .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Slider slider, Image image)
        {
            SliderImage sliderImage = new SliderImage
            {
                ImageId = image.Id,
                SliderId = slider.Id
            };

            slider.SliderImage = sliderImage;
            await _context.SaveChangesAsync();
        }

        public async Task Update(Slider slider, Image image)
        {
            var data = await GetForSliderId(slider.Id);
            data.ImageId = image.Id;
            await _context.SaveChangesAsync();
        }
    }
}
