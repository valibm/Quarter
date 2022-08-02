using Business.Services;
using Business.ViewModels;
using DAL.Data;
using DAL.Identity;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
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
        private readonly ISubCatagoryService _subCatagoryService;
        private readonly UserManager<AppUser> _userManager;
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
                                 IPropertyTypeService propertyTypeService,
                                 ISubCatagoryService subCatagoryService,
                                 UserManager<AppUser> userManager)
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
            _subCatagoryService = subCatagoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products;
            try
            {
                products = await _productService.GetAllForIndex();
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
                product = await _productService.GetForDetails(id);
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

            ProductFeature productFeature = new ProductFeature
            {
                LivingRoom = productVM.LivingRoom,
                DiningArea = productVM.DiningArea,
                Bathroom = productVM.Bathroom,
                Bedroom = productVM.Bedroom,
                Garage = productVM.Garage,
                Garden = productVM.Garden,
                GymArea = productVM.GymArea,
                Parking = productVM.Parking,
            };

            await _productFeatureService.Create(productFeature);

            productVM.AppUserId = _userManager.GetUserId(User);
            var product = await _productService.Create(productVM, productDetails.Id, productFeature.Id);

            List<Image> images = await CreateProductImage(productVM.ImageFiles);

            await _productImageService.Create(product, images);

            return RedirectToAction(nameof(AddCatagory), new { id = product.Id });
        }
        public async Task<List<Image>> CreateProductImage(List<IFormFile> images)
        {
            List<Image> newImages = new List<Image>();
            for (int i = 0; i < images.Count; i++)
            {
                if (i == 0)
                {
                    string fileName = await images[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForCard = true,
                    };
                    newImages.Add(image);
                    await _imageService.Create(image);
                }
                else if (i > 0 && i < 6)
                {
                    string fileName = await images[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForHeader = true
                    };
                    newImages.Add(image);
                    await _imageService.Create(image);
                }
                else
                {
                    string fileName = await images[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForGallery = true,
                    };
                    newImages.Add(image);
                    await _imageService.Create(image);
                }
            }
            return newImages;
        }

        //public async Task<IActionResult> CreateFloorPlan(int? id)
        //{
        //    var product = await _productService.GetForDetails(id);
        //    ViewData["product"] = product;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateFloorPlan(int id, FloorPlan floorPlan)
        //{
        //    var product = _productService.GetForDetails(id);
        //    ViewData["product"] = product;

        //    if (!ModelState.IsValid)
        //    {
        //        return View(floorPlan);
        //    }

        //    if (floorPlan.ImageFile is null)
        //    {
        //        ModelState.AddModelError("ImageFile", "Image can not be empty");
        //        return View(floorPlan);
        //    }

        //    floorPlan.ProductId = product.Id;

        //    string fileName = await floorPlan.ImageFile.CreateFile(_env);

        //    Image image = new Image
        //    {
        //        Name = fileName
        //    };

        //    await _floorPlanService.Create(floorPlan);
        //    await _imageService.Create(image);
        //    await _floorPlansImageService.Create(floorPlan, image);

        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AddCatagory(int? id)
        {
            var propertyTypes = await _propertyTypeService.GetAll();

            var propertyTypeModel = new List<PropertyTypeVM>();
            foreach (var propertyType in propertyTypes)
            {
                var propertyTypeVm = new PropertyTypeVM
                {
                    PropertyTypeId = propertyType.Id,
                    PropertyTypeName = propertyType.Name,
                    Selected = false
                };
                propertyTypeModel.Add(propertyTypeVm);
            }

            var amenities = await _amenityService.GetAll();

            var amenityModel = new List<AmenityVM>();
            foreach (var amenity in amenities)
            {
                var amenityVm = new AmenityVM
                {
                    AmenityId = amenity.Id,
                    AmenityName = amenity.Name,
                    Selected = false
                };
                amenityModel.Add(amenityVm);
            }

            AmenityTypeVM model = new AmenityTypeVM
            {
                AmenityVMs = amenityModel,
                PropertyTypeVMs = propertyTypeModel,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCatagory(int id, AmenityTypeVM amenityTypeVm)
        {
            var product = await _productService.GetForDetails(id);

            List<ProductSubCatagory> productSubCatagories = new List<ProductSubCatagory>();

            foreach (var amenityVM in amenityTypeVm.AmenityVMs)
            {
                if (amenityVM.Selected)
                {
                    ProductSubCatagory productSubCatagory = new ProductSubCatagory
                    {
                        ProductId = product.Id,
                        SubCatagoryId = amenityVM.AmenityId
                    };

                    productSubCatagories.Add(productSubCatagory);
                }
            }

            foreach (var propertyTypeVm in amenityTypeVm.PropertyTypeVMs)
            {
                if (propertyTypeVm.Selected)
                {
                    ProductSubCatagory productSubCatagory = new ProductSubCatagory
                    {
                        ProductId = product.Id,
                        SubCatagoryId = propertyTypeVm.PropertyTypeId
                    };

                    productSubCatagories.Add(productSubCatagory);
                }
            }

            await _productSubCatagoryService.CreateMultiple(productSubCatagories);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var areas = await _areaService.GetAll();
            ViewData["areas"] = areas;
            var productStatuses = await _productStatusService.GetAll();
            ViewData["productStatuses"] = productStatuses;

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
        public async Task<IActionResult> Update(int id, Product product)
        {
            var areas = await _areaService.GetAll();
            ViewData["areas"] = areas;
            var productStatuses = await _productStatusService.GetAll();
            ViewData["productStatuses"] = productStatuses;

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var data = await _productService.Get(id);

            if (product.CardFile != null)
            {
                foreach (var productImage in data.ProductImages)
                {
                    if (productImage.Image.ForCard == true)
                    {
                        string fileName = await product.CardFile.CreateFile(_env);

                        Image image = new Image
                        {
                            Name = fileName,
                            ForCard = true
                        };

                        await _imageService.Create(image);

                        int oldImageId = productImage.ImageId;

                        await _productImageService.Update(product, image);
                        await _productService.Update(id, product);
                        await _imageService.Delete(oldImageId);
                    }
                }
            }

            if (product.HeaderFiles != null)
            {
                foreach (var headerFile in product.HeaderFiles)
                {
                    foreach (var productImage in data.ProductImages)
                    {
                        if (productImage.Image.ForHeader == true)
                        {
                            string fileName = await headerFile.CreateFile(_env);

                            Image image = new Image
                            {
                                Name = fileName,
                                ForHeader = true
                            };

                            await _imageService.Create(image);

                            int oldImageId = productImage.ImageId;

                            await _productImageService.Update(product, image);
                            await _productService.Update(id, product);
                            await _imageService.Delete(oldImageId);
                        }
                    }
                }
            }

            if (product.ImageFiles != null)
            {
                foreach (var imageFile in product.ImageFiles)
                {
                    foreach (var productImage in data.ProductImages)
                    {
                        if (productImage.Image.ForGallery == true)
                        {
                            string fileName = await imageFile.CreateFile(_env);

                            Image image = new Image
                            {
                                Name = fileName,
                                ForGallery = true
                            };

                            await _imageService.Create(image);

                            int oldImageId = productImage.ImageId;

                            await _productImageService.Update(product, image);
                            await _productService.Update(id, product);
                            await _imageService.Delete(oldImageId);
                        }
                    }
                }
            }

            await _productService.Update(id, product);

            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _productService.Delete(id);
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
