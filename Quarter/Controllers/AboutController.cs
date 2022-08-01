using Business.Services;
using Business.ViewModels;
using DAL.Data;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class AboutController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AboutController(IServiceService serviceService, 
                                 IBlogService blogService,
                                 AppDbContext context,
                                 UserManager<AppUser> userManager)
        {
            _serviceService = serviceService;
            _blogService = blogService;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = _userManager.GetUsersInRoleAsync("Admin").Result;
            var adminIds = admins.Select(u => u.Id);

            var users = await _context.Users.Where(u => adminIds.Contains(u.Id))
                                            .Include(n => n.Image)
                                            .Take(3)
                                            .ToListAsync();

            AboutUsVM aboutUsVM = new AboutUsVM();

            aboutUsVM.Services = await _serviceService.GetForHome();
            aboutUsVM.Blogs = await _blogService.GetForHome();
            aboutUsVM.Users = users;

            return View(aboutUsVM);
        }
    }
}
