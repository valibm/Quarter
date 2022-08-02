using Business.Services;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SubCatagoryController : Controller
    {
        private readonly ICatagoryService _catagoryService;
        private readonly ISubCatagoryService _subCatagoryService;
        public SubCatagoryController(ICatagoryService catagoryService, ISubCatagoryService subCatagoryService)
        {
            _catagoryService = catagoryService;
            _subCatagoryService = subCatagoryService;
        }
        public async Task<IActionResult> Index()
        {
            List<SubCatagory> subCatagories;
            try
            {
                subCatagories = await _subCatagoryService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(subCatagories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            SubCatagory subCatagory;
            try
            {
                subCatagory = await _subCatagoryService.Get(id);
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
            return View(subCatagory);
        }

        public async Task<IActionResult> Create()
        {
            var catagories = await _catagoryService.GetAll();
            ViewData["catagories"] = catagories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCatagory subCcatagory)
        {
            var catagories = await _catagoryService.GetAll();
            ViewData["catagories"] = catagories;

            if (!ModelState.IsValid)
            {
                return View(subCcatagory);
            }

            await _subCatagoryService.Create(subCcatagory);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var catagories = await _catagoryService.GetAll();
            ViewData["catagories"] = catagories;

            SubCatagory subCatagory;
            try
            {
                subCatagory = await _subCatagoryService.Get(id);
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
            return View(subCatagory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SubCatagory subCatagory)
        {
            var catagories = await _catagoryService.GetAll();
            ViewData["catagories"] = catagories;

            if (!ModelState.IsValid)
            {
                return View(subCatagory);
            }

            await _subCatagoryService.Update(id, subCatagory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                await _subCatagoryService.Delete(id);
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
