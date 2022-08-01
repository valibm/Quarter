using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatagoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;
        public CatagoryController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Catagory> catagories;
            try
            {
                catagories = await _catagoryService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(catagories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Catagory catagory;
            try
            {
                catagory = await _catagoryService.Get(id);
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
            return View(catagory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View(catagory);
            }

            await _catagoryService.Create(catagory);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {

            Catagory catagory;
            try
            {
                catagory = await _catagoryService.Get(id);
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
            return View(catagory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Catagory catagory)
        {

            if (!ModelState.IsValid)
            {
                return View(catagory);
            }

            await _catagoryService.Update(id, catagory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                await _catagoryService.Delete(id);
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

            return RedirectToAction(nameof(Index));
        }
    }
}
