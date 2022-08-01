using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Quarter.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IPropertyTypeService _propertyTypeService;
        private readonly ITagService _tagService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(IBlogService blogService, 
                              IPropertyTypeService propertyTypeService,
                              ITagService tagService,
                              ICommentService commentService,
                              UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _propertyTypeService = propertyTypeService;
            _tagService = tagService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAll();
            var catagories = await _propertyTypeService.GetForWidget();
            var tags = await _tagService.GetForWidget();

            BlogVM blogVm = new BlogVM
            {
                Blogs = blogs,
                Catagories = catagories,
                Tags = tags
            };

            return View(blogVm);
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            var blog = await _blogService.Get(id);
            var catagories = await _propertyTypeService.GetForWidget();
            var tags = await _tagService.GetForWidget();
            var latestBlogs = await _blogService.GetForWidget(blog);
            var relatedBlogs = await _blogService.GetRelated(blog.BlogTags);
            var comments = await _commentService.GetForBlog(id);

            BlogDetailVM blogDetailVm = new BlogDetailVM
            {
                Blog = blog,
                Catagories = catagories,
                Tags = tags,
                LatestBlogs = latestBlogs,
                RelatedBlogs = relatedBlogs,
                Comments = comments
            };

            return View(blogDetailVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromForm] Comment comment)
        {
            comment.AppUserId = _userManager.GetUserId(User);

            await _commentService.Create(comment);

            return RedirectToAction(nameof(BlogDetail), new {id = comment.BlogId});
        }
    }
}
