using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Tag : BaseEntity, IEntity
    {
        public string Name { get; set; }

        public List<BlogTag> BlogTags { get; set; }
    }
}
