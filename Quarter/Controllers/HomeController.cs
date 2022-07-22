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
        public HomeController(ISliderService sliderService, IServiceService serviceService)
        {
            _sliderService = sliderService;
            _serviceService = serviceService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();

            homeVm.Sliders = await _sliderService.GetAll();
            homeVm.Services = await _serviceService.GetAll();

            return View(homeVm);
        }
    }
}
