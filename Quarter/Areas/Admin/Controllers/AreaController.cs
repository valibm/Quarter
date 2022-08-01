using Business.Services;
using DAL.Identity;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;
        private readonly ILocationService _locationService;
        public AreaController(IAreaService areaService, 
                              ILocationService locationService)
        {
            _areaService = areaService;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            List<Area> areas;
            try
            {
                areas = await _areaService.GetAll();
            }
            catch (EntityIsNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(areas);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Area area;
            try
            {
                area = await _areaService.Get(id);
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
            return View(area);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var locations = await _locationService.GetAll();
            ViewData["locations"] = locations;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Area area)
        {
            var locations = await _locationService.GetAll();
            ViewData["locations"] = locations;

            if (!ModelState.IsValid)
            {
                return View(area);
            }

            await _areaService.Create(area);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var locations = await _locationService.GetAll();
            ViewData["locations"] = locations;

            Area area;
            try
            {
                area = await _areaService.Get(id);
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
            return View(area);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Area area)
        {
            var locations = await _locationService.GetAll();
            ViewData["locations"] = locations;

            if (!ModelState.IsValid)
            {
                return View(area);
            }

            await _areaService.Update(id, area);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {

            try
            {
                await _areaService.Delete(id);
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
