using Business.Services;
using Business.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quarter.Controllers
{
    public class ServiceDetailsController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceDetailsController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Service service;
            List<Service> services;
            try
            {
                service = await _serviceService.Get(id);
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
            
            try
            {
                services = await _serviceService.GetAll();
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

            ServiceVM serviceVm = new ServiceVM
            {
                Service = service,
                AllServices = services,
            };

            return View(serviceVm);
        }
    }
}
