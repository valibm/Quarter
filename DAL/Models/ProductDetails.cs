using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductDetails: IEntity
    {
        public int Id { get; set; }
        public double HomeArea { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public int YearBuilt { get; set; }
        public double LotDimensions { get; set; }
        public int Beds { get; set; }
        public double Price { get; set; }
    }
}
