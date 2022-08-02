using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Service : BaseEntity, IEntity
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Description { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Content { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public IFormFile CardFile { get; set; }
        [NotMapped]
        public IFormFile HeaderFile { get; set; }
        [NotMapped]
        public IFormFile BannerFile { get; set; }
        public List<ServiceImage> ServiceImages { get; set; }
    }
}
