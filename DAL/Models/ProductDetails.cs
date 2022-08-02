using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class ProductDetails: IEntity
    {
        public int Id { get; set; }
        [Required, Range(1, 500)]
        public double HomeArea { get; set; }
        [Required, Range(1, 50)]
        public int Rooms { get; set; }
        [Required, Range(1, 50)]
        public int Baths { get; set; }
        [Required]
        public int YearBuilt { get; set; }
        [Required, Range(1, 500)]
        public double LotDimensions { get; set; }
        [Required, Range(1, 50)]
        public int Beds { get; set; }
        [Required, Range(1, 500000)]
        public double Price { get; set; }
    }
}
