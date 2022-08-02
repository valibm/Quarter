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
    public class Slider : BaseEntity, IEntity
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string SubTitle { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Content { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public SliderImage SliderImage { get; set; }
    }
}
