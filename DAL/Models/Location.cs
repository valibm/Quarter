using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Country { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string City { get; set; }

        public List<Area> Areas { get; set; }
    }
}
