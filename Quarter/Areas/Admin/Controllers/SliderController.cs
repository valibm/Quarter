using Business.Repositories;
using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly ISliderImageService _sliderImageService;
        public SliderController(ISliderService sliderService, 
                                IImageService imageService,
                                IWebHostEnvironment env,
                                ISliderImageService sliderImageService)
        {
            _sliderService = sliderService;
            _imageService = imageService;
            _env = env;
            _sliderImageService = sliderImageService;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders;
            try
            {
                sliders = await _sliderService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (slider.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(slider);
            }

            string fileName = await slider.ImageFile.CreateFile(_env);

            Image image = new Image();
            image.Name = fileName;
            
            await _sliderService.Create(slider);
            await _imageService.Create(image);
            await _sliderImageService.Create(slider, image);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            Slider slider;
            try
            {
                slider = await _sliderService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            return View(slider);
        }

        public async Task<IActionResult> Update(int? id)
        {

            Slider slider;
            try
            {
                slider = await _sliderService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Slider slider)
        {

            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            if (slider.ImageFile != null)
            {
                string fileName = await slider.ImageFile.CreateFile(_env);

                Image image = new Image();
                image.Name = fileName;

                await _imageService.Create(image);

                int oldImageId = slider.SliderImage.ImageId;

                await _sliderImageService.Update(slider, image);
                await _sliderService.Update(id, slider);
                await _imageService.Delete(oldImageId);
            }

            await _sliderService.Update(id, slider);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Slider slider;
            try
            {
                slider = await _sliderService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                await _sliderService.Delete(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                await _imageService.Delete(slider.SliderImage.ImageId);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
