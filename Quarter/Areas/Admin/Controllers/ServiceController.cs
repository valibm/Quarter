using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
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

        public async Task<IActionResult> Details(int? id)
        {
            Service service;
            try
            {
                service = await _serviceService.Get(id);
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
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            List<Image> images = new List<Image>();

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

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            Service service;
            try
            {
                service = await _serviceService.Get(id);
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

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            var data = await _serviceService.Get(id);

            if (service.CardFile != null)
            {
                foreach (var serviceImage in data.ServiceImages)
                {
                    if (serviceImage.Image.ForCard == true)
                    {
                        string fileName = await service.CardFile.CreateFile(_env);

                        Image image = new Image
                        {
                            Name = fileName,
                            ForCard = true
                        };

                        await _imageService.Create(image);

                        int oldImageId = serviceImage.ImageId;

                        await _serviceImageService.Update(service, image);
                        await _serviceService.Update(id, service);
                        await _imageService.Delete(oldImageId);
                    }
                }
            }

            if (service.HeaderFile != null)
            {
                foreach (var serviceImage in data.ServiceImages)
                {
                    if (serviceImage.Image.ForHeader == true)
                    {
                        string fileName = await service.HeaderFile.CreateFile(_env);

                        Image image = new Image
                        {
                            Name = fileName,
                            ForHeader = true
                        };

                        await _imageService.Create(image);

                        int oldImageId = serviceImage.ImageId;

                        await _serviceImageService.Update(service, image);
                        await _serviceService.Update(id, service);
                        await _imageService.Delete(oldImageId);
                    }
                }
            }

            if (service.BannerFile != null)
            {
                foreach (var serviceImage in data.ServiceImages)
                {
                    if (serviceImage.Image.ForBanner == true)
                    {
                        string fileName = await service.BannerFile.CreateFile(_env);

                        Image image = new Image
                        {
                            Name = fileName,
                            ForBanner = true
                        };

                        await _imageService.Create(image);

                        int oldImageId = serviceImage.ImageId;

                        await _serviceImageService.Update(service, image);
                        await _serviceService.Update(id, service);
                        await _imageService.Delete(oldImageId);
                    }
                }
            }

            if (service.ImageFiles != null)
            {
                foreach (var imageFile in service.ImageFiles)
                {
                    foreach (var serviceImage in data.ServiceImages)
                    {
                        if (serviceImage.Image.ForGallery == true)
                        {
                            string fileName = await imageFile.CreateFile(_env);

                            Image image = new Image
                            {
                                Name = fileName,
                                ForGallery = true
                            };

                            await _imageService.Create(image);

                            int oldImageId = serviceImage.ImageId;

                            await _serviceImageService.Update(service, image);
                            await _serviceService.Update(id, service);
                            await _imageService.Delete(oldImageId);
                        }
                    }
                }
            }

            await _serviceService.Update(id, service);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _serviceService.Delete(id);
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
