using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class SubCatagory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
    }
}
