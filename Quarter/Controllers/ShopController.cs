using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAreaService _areaService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;
        public ShopController(IProductService productService, 
                              IAreaService areaService,
                              UserManager<AppUser> userManager,
                              ICommentService commentService)
        {
            _productService = productService;
            _areaService = areaService;
            _userManager = userManager;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        public async Task<IActionResult> ShowByArea(int? id)
        {
            var area = await _areaService.GetForArea(id);
            return View(area.Products);
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {
            var product = await _productService.Get(id);

            var comments = await _commentService.GetForProduct(id);

            ShopVM shopVm = new ShopVM();

            shopVm.Product = product;
            shopVm.Comments = comments;

            return View(shopVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromForm] Comment comment)
        {
            comment.AppUserId = _userManager.GetUserId(User);

            await _commentService.Create(comment);

            return RedirectToAction(nameof(ProductDetail), new { id = comment.ProductId});
        }
    }
}
