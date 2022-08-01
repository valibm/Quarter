using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<Blog> RelatedBlogs { get; set; }
        public List<Tag> Tags { get; set; }
        public List<SubCatagory> Catagories { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
