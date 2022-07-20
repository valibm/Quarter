using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class SliderImage : IEntity
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
