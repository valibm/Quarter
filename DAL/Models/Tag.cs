using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Tag : BaseEntity, IEntity
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public List<BlogTag> BlogTags { get; set; }
    }
}
