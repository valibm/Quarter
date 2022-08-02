using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Blog : BaseEntity, IEntity
    {
        [Required, MinLength(3)]
        public string Title { get; set; }
        [Required, MinLength(3)]
        public string Content { get; set; }
        [Required, MinLength(3)]
        public string Description { get; set; }
        public List<BlogImage> BlogImages{ get; set; }
        public List<BlogTag> BlogTags { get; set; }
        public List<Comment> Comments { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public IFormFile CardFile { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
