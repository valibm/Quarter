using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductService _productService;
        public ProductDetailsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var products = await _productService.Get(id);
            return View(products);
        }
    }
}
