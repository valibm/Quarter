using Business.Services;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;
        private readonly IProductService _productService;
        private readonly IBlogService _blogService;
        private readonly IAreaService _areaService;
        public HomeController(ISliderService sliderService, 
                              IServiceService serviceService,
                              IProductService productService,
                              IBlogService blogService,
                              IAreaService areaService)
        {
            _sliderService = sliderService;
            _serviceService = serviceService;
            _productService = productService;
            _blogService = blogService;
            _areaService = areaService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();

            homeVm.Sliders = await _sliderService.GetAll();
            homeVm.Services = await _serviceService.GetForHome();
            homeVm.Products = await _productService.GetForHome();
            homeVm.Blogs = await _blogService.GetForHome();
            homeVm.Areas = await _areaService.GetForHome();

            return View(homeVm);
        }
    }
}
