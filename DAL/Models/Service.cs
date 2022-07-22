using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Service : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        public List<ServiceImage> ServiceImages { get; set; }
    }
}
