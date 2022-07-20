using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductFeature : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
