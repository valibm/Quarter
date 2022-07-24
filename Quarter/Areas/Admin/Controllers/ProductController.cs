using Business.Services;
using Business.ViewModels;
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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        private readonly IAreaService _areaService;
        private readonly IProductStatusService _productStatusService;
        private readonly IProductDetailsService _productDetailsService;
        private readonly IProductFeatureService _productFeatureService;
        private readonly IProductImageService _productImageService;
        private readonly IAmenityService _amenityService;
        private readonly IFloorPlanService _floorPlanService;
        private readonly IFloorPlansImageService _floorPlansImageService;
        private readonly IFloorFeatureService _floorFeatureService;
        private readonly IProductSubCatagoryService _productSubCatagoryService;
        private readonly IPropertyTypeService _propertyTypeService;
        public ProductController(IProductService productService,
                                 IImageService imageService,
                                 IWebHostEnvironment env,
                                 IAreaService areaService,
                                 IProductStatusService productStatusService,
                                 IProductDetailsService productDetailsService,
                                 IProductFeatureService productFeatureService,
                                 IProductImageService productImageService,
                                 IAmenityService amenityService,
                                 IFloorPlanService floorPlanService,
                                 IFloorPlansImageService floorPlansImageService,
                                 IFloorFeatureService floorFeatureService,
                                 IProductSubCatagoryService productSubCatagoryService,
                                 IPropertyTypeService propertyTypeService)
        {
            _productService = productService;
            _imageService = imageService;
            _env = env;
            _areaService = areaService;
            _productStatusService = productStatusService;
            _productDetailsService = productDetailsService;
            _productFeatureService = productFeatureService;
            _productImageService = productImageService;
            _amenityService = amenityService;
            _floorPlanService = floorPlanService;
            _floorPlansImageService = floorPlansImageService;
            _floorFeatureService = floorFeatureService;
            _productSubCatagoryService = productSubCatagoryService;
            _propertyTypeService = propertyTypeService;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products;

            try
            {
                products = await _productService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Product product;
            try
            {
                product = await _productService.Get(id);
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
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            var areas = await _areaService.GetAll();
            ViewData["areas"] = areas;
            var productStatuses = await _productStatusService.GetAll();
            ViewData["productStatuses"] = productStatuses;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVM productVM)
        {
            var areas = await _areaService.GetAll();
            ViewData["areas"] = areas;
            var productStatuses = await _productStatusService.GetAll();
            ViewData["productStatuses"] = productStatuses;

            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            if (productVM.ImageFiles is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(productVM);
            }

            ProductDetails productDetails = new ProductDetails
            {
                HomeArea = productVM.HomeArea,
                Rooms = productVM.Rooms,
                Baths = productVM.Baths,
                YearBuilt = productVM.YearBuilt,
                LotDimensions = productVM.LotDimensions,
                Beds = productVM.Beds,
                Price = productVM.Price,
            };

            await _productDetailsService.Create(productDetails);

            var product = await _productService.Create(productVM, productDetails);

            List<Image> images = new List<Image>();
            for (int i = 0; i < productVM.ImageFiles.Count; i++)
            {
                if (i == 0)
                {
                    string fileName = await productVM.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForCard = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else if (i > 0 && i < 6)
                {
                    string fileName = await productVM.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForHeader = true
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else
                {
                    string fileName = await productVM.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForGallery = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
            }

            await _productImageService.Create(product, images);

            return RedirectToAction(nameof(CreateFeature));
        }

        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeature(ProductFeature productFeature)
        {
            var products = await _productService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(productFeature);
            }

            productFeature.ProductId = products[^1].Id;

            await _productFeatureService.Create(productFeature);

            return View();
        }

        public IActionResult CreateFloorPlan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFloorPlan(FloorPlan floorPlan)
        {
            var products = await _productService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(floorPlan);
            }

            if (floorPlan.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(floorPlan);
            }

            floorPlan.ProductId = products[^1].Id;

            string fileName = await floorPlan.ImageFile.CreateFile(_env);

            Image image = new Image
            {
                Name = fileName
            };

            await _floorPlanService.Create(floorPlan);
            await _imageService.Create(image);
            await _floorPlansImageService.Create(floorPlan, image);

            return View();
        }

        public async Task<IActionResult> CreateFloorFeature()
        {
            var floorPlans = await _floorPlanService.GetAll();
            ViewData["floorPlans"] = floorPlans;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFloorFeature(FloorFeature floorFeature)
        {
            var floorPlans = await _floorPlanService.GetAll();
            ViewData["floorPlans"] = floorPlans;

            if (!ModelState.IsValid)
            {
                return View(floorFeature);
            }

            await _floorFeatureService.Create(floorFeature);

            return View();
        }

        public async Task<IActionResult> AddAmenity()
        {
            var amenities = await _amenityService.GetAll();
            ViewData["amenities"] = amenities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAmenity(ProductSubCatagory productSubCatagory)
        {
            var amenities = await _amenityService.GetAll();
            ViewData["amenities"] = amenities;

            var products = await _productService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(productSubCatagory);
            }

            productSubCatagory.ProductId = products[^1].Id;

            await _productSubCatagoryService.Create(productSubCatagory);

            return View();
        }

        public async Task<IActionResult> AddPropertyType()
        {
            var propertyTypes = await _propertyTypeService.GetAll();
            ViewData["propertyTypes"] = propertyTypes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPropertyType(ProductSubCatagory productSubCatagory)
        {
            var propertyTypes = await _propertyTypeService.GetAll();
            ViewData["propertyTypes"] = propertyTypes;

            var products = await _productService.GetAll();

            if (!ModelState.IsValid)
            {
                return View(productSubCatagory);
            }

            productSubCatagory.ProductId = products[^1].Id;

            await _productSubCatagoryService.Create(productSubCatagory);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            Product product;
            try
            {
                product = await _productService.Get(id);
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

            return View(product);
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
    }
}
