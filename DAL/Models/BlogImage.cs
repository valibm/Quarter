using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class BlogImage
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
