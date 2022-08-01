using DAL.Data;
using DAL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public TeamController(AppDbContext context,
                              UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = _userManager.GetUsersInRoleAsync("Admin").Result;
            var adminIds = admins.Select(u => u.Id);

            var users = await _context.Users.Where(u => adminIds.Contains(u.Id)).Include(n => n.Image).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> TeamDetail(string id)
        {
            var user = await _context.Users.Where(n => n.Id == id)
                                           .Include(n => n.Image)
                                           .Include(n => n.Position)
                                           .FirstOrDefaultAsync();

            return View(user);
        }
    }
}
