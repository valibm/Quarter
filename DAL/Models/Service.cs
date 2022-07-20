using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Service : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public List<Image> Images { get; set; }
    }
}
