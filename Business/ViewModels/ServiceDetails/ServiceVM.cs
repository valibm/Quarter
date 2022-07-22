using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class ServiceVM
    {
        public Service Service { get; set; }
        public List<Service> AllServices { get; set; }
    }
}
