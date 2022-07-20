using Business.Services;
using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        public HomeController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();

            homeVm.Sliders = await _sliderService.GetAll();

            return View(homeVm);
        }
    }
}
