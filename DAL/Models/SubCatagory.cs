using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class SubCatagory : IEntity
    {
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }

        public List<ProductSubCatagory> ProductSubCatagories { get; set; }
    }
}
