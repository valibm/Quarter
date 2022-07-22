using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ISliderImageService
    {
        public Task<SliderImage> GetForSliderId(int? id);
        public Task Create(Slider slider, Image image);
        public Task Update(Slider slider, Image image);
    }
}
