using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductCatagory : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SubCatagoryId { get; set; }
        public SubCatagory SubCatagory { get; set; }
    }
}
