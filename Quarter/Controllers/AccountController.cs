using Business.Services;
using Business.ViewModels;
using DAL.Data;
using DAL.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quarter.Helpers.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Utilities.Helpers.Enums;

namespace Quarter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager,
                                 AppDbContext context,
                                 IImageService imageService,
                                 IWebHostEnvironment env)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _imageService = imageService;
            _env = env;
        }

        [HttpGet(nameof(Register))]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterVM registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVm);
            }

            AppUser appUser = new AppUser();

            appUser.FirstName = registerVm.Firstname;
            appUser.LastName = registerVm.Lastname;
            appUser.Email = registerVm.Email;
            appUser.UserName = registerVm.Username;

            var result = await _userManager.CreateAsync(appUser, registerVm.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVm);
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, Roles.Member.ToString());

            if (!roleResult.Succeeded)
            {
                foreach (var item in roleResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVm);
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        [HttpGet(nameof(Login))]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            AppUser appUser = await _userManager.FindByNameAsync(loginVM.Username);

            if (appUser is null)
            {
                ModelState.AddModelError("", "Username is wrong");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Please confirm your account");
                return View(loginVM);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your profile is locked out.\nPlease try again later.");
                return View(loginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid password");
                return View(loginVM);
            }

            if (await _userManager.IsInRoleAsync(appUser, Roles.Admin.ToString()))
            {
                return RedirectToAction("Index", controllerName: "Dashboard", new { Areas = "Admin" });
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", controllerName: "Home");
        }

        public async Task CreateRoles()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }
        }

        public async Task<IActionResult> Profile()
        {
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userID = _userManager.GetUserId(User);
            var appUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();

            return View(appUser);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AppUser appUser)
        {
            //var newAppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userID = _userManager.GetUserId(User);
            var newAppUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();
            newAppUser.Information = appUser.Information;
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

        public async Task<IActionResult> UpdateProfile()
        {
            //var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userID = _userManager.GetUserId(User);
            var appUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();

            return View(appUser);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(AppUser appUser)
        {
            //var newAppUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userID = _userManager.GetUserId(User);
            var newAppUser = await _context.Users.Where(n => n.Id == userID)
                                              .Include(n => n.Image)
                                              .FirstOrDefaultAsync();
            newAppUser.Information = appUser.Information;
            string fileName = await appUser.ImageFile.CreateFile(_env);

            Image image = new Image
            {
                Name = fileName,
            };
            await _imageService.Create(image);

            int? oldImageId = newAppUser.ImageId;
            await _imageService.Delete(oldImageId);

            newAppUser.ImageId = image.Id;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Profile));
        }

        //public async Task<IActionResult> AccountDetails()
        //{
        //    var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        //    return View(appUser);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAccountDetails(AccountDetailsVM accountDetailsVM)
        //{
        //    var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        //    appUser.Information = accountDetailsVM.Information;
        //    appUser.SubInformation = accountDetailsVM.SubInformation;
        //    appUser.Experience = accountDetailsVM.Experience;
        //    appUser.PracticeArea = accountDetailsVM.PracticeArea;
        //    appUser.Location = accountDetailsVM.Location;
        //    appUser.PositionId = accountDetailsVM.PositionId;
        //    appUser.FacebookLink = accountDetailsVM.FacebookLink;
        //    appUser.LinkedInLink = accountDetailsVM.LinkedInLink;
        //    appUser.TwitterLink = accountDetailsVM.TwitterLink;
        //    return View();
        //}
    }
}
