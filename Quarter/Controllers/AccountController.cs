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
using System.Net;
using System.Net.Mail;
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

            return await EmailConfirmation(appUser);
        }

        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            var appUser = await _userManager.FindByNameAsync(userName);
            if (appUser is null)
            {
                return Json("user not found");
            }
            await _userManager.ConfirmEmailAsync(appUser, token);
            return RedirectToAction("index", controllerName: "Home");
        }

        public async Task<IActionResult> EmailConfirmation(AppUser appUser)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string redirectionLink = Url.Action(nameof(ConfirmEmail), controller: "Account", new { userName = appUser.UserName, token = token }, protocol: HttpContext.Request.Scheme);
            string linkTag = $"<a href=\"{redirectionLink}\">Click here to confirm your email</a>";
            await SendEmail(linkTag, appUser.Email);
            return Json("please check your email to confirm you email.");
        }

        public async Task<IActionResult> SendEmail(string htmlTag, string userMail)
        {
            string from = "valibm@code.edu.az";
            string to = userMail;
            string subject = "Quarter Email Confirmation";
            string body = htmlTag;
            MailMessage message = new MailMessage(from, to, subject, body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;


            NetworkCredential credential = new NetworkCredential(from, "arnodorian002");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = credential;


            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json("ok");

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
                return RedirectToAction("Index", "Dashboard", new { area = "admin" });
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
    }
}
