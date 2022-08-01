using Business.Services;
using Business.ViewModels;
using DAL.Identity;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quarter.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;
        private readonly IImageService _imageService;
        private readonly IBlogImageService _blogImageService;
        private readonly ITagService _tagService;
        private readonly IBlogTagService _blogTagService;
        private readonly UserManager<AppUser> _userManager;
        public BlogController(IBlogService blogService,
                              IWebHostEnvironment env,
                              IImageService imageService,
                              IBlogImageService blogImageService,
                              ITagService tagService,
                              IBlogTagService blogTagService,
                              UserManager<AppUser> userManager)
        {
            _blogService = blogService;
            _env = env;
            _imageService = imageService;
            _blogImageService = blogImageService;
            _tagService = tagService;
            _blogTagService = blogTagService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs;
            try
            {
                blogs = await _blogService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(blogs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Blog blog;
            try
            {
                blog = await _blogService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            if (blog.ImageFiles is null)
            {
                ModelState.AddModelError("ImageFile", "Image can not be empty");
                return View(blog);
            }

            blog.AppUserId = _userManager.GetUserId(User);
            await _blogService.Create(blog);

            List<Image> images = new List<Image>();

            for (int i = 0; i < blog.ImageFiles.Count; i++)
            {
                if (i == 0)
                {
                    string fileName = await blog.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForCard = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
                else
                {
                    string fileName = await blog.ImageFiles[i].CreateFile(_env);
                    Image image = new Image
                    {
                        Name = fileName,
                        ForGallery = true,
                    };
                    images.Add(image);
                    await _imageService.Create(image);
                }
            }

            await _blogImageService.Create(blog, images);

            return RedirectToAction(nameof(AddTag), new {id = blog.Id});
        }

        [HttpGet]
        public async Task<IActionResult> AddTag()
        {
            var tags = await _tagService.GetAll();
            
            var model = new List<TagVM>();
            foreach (var tag in tags)
            {
                var tagVm = new TagVM
                {
                    TagId = tag.Id,
                    TagName = tag.Name,
                    Selected = false
                };
                model.Add(tagVm);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(int id, List<TagVM> tagVMs)
        {
            Blog blog = await _blogService.Get(id);

            List<BlogTag> blogTags = new List<BlogTag>();
            foreach (var tagVm in tagVMs)
            {
                if (tagVm.Selected)
                {
                    BlogTag blogTag = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = tagVm.TagId,
                    };
                    blogTags.Add(blogTag);
                }
            }

            await _blogTagService.Create(blogTags);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            Blog blog;
            try
            {
                blog = await _blogService.Get(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            var data = await _blogService.Get(id);
            List<Image> images = new List<Image>();

            if (blog.CardFile != null)
            {
                foreach (var blogImage in data.BlogImages)
                {
                    if (blogImage.Image.ForCard == true)
                    {
                        string fileName = await blog.CardFile.CreateFile(_env);

                        Image image = new Image
                        {
                            Name = fileName,
                            ForCard = true
                        };

                        await _imageService.Create(image);

                        int oldImageId = blogImage.ImageId;

                        images.Add(image);
                        await _imageService.Delete(oldImageId);
                    }
                }
            }

            if (blog.ImageFiles != null)
            {
                foreach (var imageFile in blog.ImageFiles)
                {
                    foreach (var blogImage in data.BlogImages)
                    {
                        if (blogImage.Image.ForGallery == true)
                        {
                            string fileName = await imageFile.CreateFile(_env);

                            Image image = new Image
                            {
                                Name = fileName,
                                ForGallery = true
                            };

                            await _imageService.Create(image);

                            int oldImageId = blogImage.ImageId;

                            images.Add(image);
                            await _imageService.Delete(oldImageId);
                        }
                    }
                }
            }

            await _blogImageService.UpdateMultiple(blog, images);
            await _blogService.Update(id, blog);

            return RedirectToAction(nameof(UpdateTag), new { id = blog.Id });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTag(int id)
        {
            var blog = await _blogService.Get(id);
            var tags = await _tagService.GetAll();

            var model = new List<TagVM>();
            foreach (var tag in tags)
            {
                var tagVm = new TagVM
                {
                    TagId = tag.Id,
                    TagName = tag.Name,
                };
                if (_blogService.ContainsTag(blog, tag))
                {
                    tagVm.Selected = true;
                }
                else
                {
                    tagVm.Selected = false;
                }
                model.Add(tagVm);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTag(int id, List<TagVM> tagVMs)
        {
            await _blogTagService.Remove(id);

            List<BlogTag> blogTags = new List<BlogTag>();
            foreach (var tagVm in tagVMs)
            {
                if (tagVm.Selected)
                {
                    BlogTag blogTag = new BlogTag
                    {
                        BlogId = id,
                        TagId = tagVm.TagId,
                    };
                    blogTags.Add(blogTag);
                }
            }

            await _blogTagService.Create(blogTags);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _blogService.Delete(id);
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
