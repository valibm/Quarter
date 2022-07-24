using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Catagory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCatagory> SubCatagories { get; set; }
    }
}
