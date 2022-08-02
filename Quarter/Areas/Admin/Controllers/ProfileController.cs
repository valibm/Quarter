using Business.Services;
using DAL.Data;
using DAL.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarter.Helpers.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;
        private readonly IPositionService _positionService;

        public ProfileController(UserManager<AppUser> userManager,
                                 AppDbContext context,
                                 IImageService imageService,
                                 IWebHostEnvironment env,
                                 IPositionService positionService)
        {
            _userManager = userManager;
            _context = context;
            _imageService = imageService;
            _env = env;
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserId(User);

            var appUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();

            var positions = await _positionService.GetAll();
            ViewData["positions"] = positions;

            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var positions = await _positionService.GetAll();
            ViewData["positions"] = positions;

            var newAppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            newAppUser.Information = appUser.Information;
            newAppUser.SubInformation = appUser.SubInformation;
            newAppUser.PhoneNumber = appUser.PhoneNumber;
            newAppUser.Experience = appUser.Experience;
            newAppUser.Location = appUser.Location;
            newAppUser.LinkedInLink = appUser.LinkedInLink;
            newAppUser.FacebookLink = appUser.FacebookLink;
            newAppUser.TwitterLink = appUser.TwitterLink;
            newAppUser.PracticeArea = appUser.PracticeArea;
            newAppUser.PositionId = appUser.PositionId;

            string fileName = await appUser.ImageFile.CreateFile(_env);

            Image image = new Image
            {
                Name = fileName,
            };
            await _imageService.Create(image);
            newAppUser.ImageId = image.Id;
            await _context.SaveChangesAsync();
            return View(newAppUser);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userID = _userManager.GetUserId(User);
            var appUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();

            var positions = await _positionService.GetAll();
            ViewData["positions"] = positions;

            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(AppUser appUser)
        {
            var positions = await _positionService.GetAll();
            ViewData["positions"] = positions;

            var newAppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            newAppUser.Information = appUser.Information;
            newAppUser.SubInformation = appUser.SubInformation;
            newAppUser.PhoneNumber = appUser.PhoneNumber;
            newAppUser.Experience = appUser.Experience;
            newAppUser.Location = appUser.Location;
            newAppUser.LinkedInLink = appUser.LinkedInLink;
            newAppUser.FacebookLink = appUser.FacebookLink;
            newAppUser.TwitterLink = appUser.TwitterLink;
            newAppUser.PracticeArea = appUser.PracticeArea;
            newAppUser.PositionId = appUser.PositionId;

            string fileName = await appUser.ImageFile.CreateFile(_env);

            Image image = new Image
            {
                Name = fileName,
            };
            await _imageService.Create(image);

            var oldImageId = newAppUser.ImageId;
            await _imageService.Delete(oldImageId);

            newAppUser.ImageId = image.Id;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
