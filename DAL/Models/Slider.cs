using DAL.Base;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
