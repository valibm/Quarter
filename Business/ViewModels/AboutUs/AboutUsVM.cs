using DAL.Identity;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class AboutUsVM
    {
        public List<Service> Services { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<AppUser> Users { get; set; }
    }
}
