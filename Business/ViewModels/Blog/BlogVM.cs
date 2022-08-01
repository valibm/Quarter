using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class BlogVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Tag> Tags { get; set; }
        public List<SubCatagory> Catagories { get; set; }
    }
}
