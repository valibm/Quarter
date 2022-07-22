using Business.Services;
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
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly IServiceImageService _serviceImageService;
        public ServiceController(IServiceService serviceService, 
                                 IImageService imageService,
                                 IWebHostEnvironment env,
                                 IServiceImageService serviceImageService)
        {
            _serviceService = serviceService;
            _imageService = imageService;
            _env = env;
            _serviceImageService = serviceImageService;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services;
            try
            {
                services = await _serviceService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(services);
        }

        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            if (service.ImageFiles is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(service);
            }

            await _serviceService.Create(service);

            List<Image> images  = new List<Image>();

            for (int i = 0; i < service.ImageFiles.Count; i++)
            {
                if (i == 0)
                {
                    string fileName = await service.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForCard = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else if (i == 1)
                {
                    string fileName = await service.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForHeader = true
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else if (i == 2)
                {
                    string fileName = await service.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForBanner = true
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else
                {
                    string fileName = await service.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForGallery = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
            }

            await _serviceImageService.Create(service, images);

            return RedirectToAction(nameof(Index));
        }
    }
}
