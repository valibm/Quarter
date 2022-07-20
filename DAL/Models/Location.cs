using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public List<Area> Areas { get; set; }
    }
}
