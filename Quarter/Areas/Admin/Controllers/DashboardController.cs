using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ICommentService _commentService;
        public DashboardController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetForManagingAll();

            return View(comments);
        }

        public async Task<IActionResult> ManageComment(int id)
        {
            await _commentService.Allow(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
