using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Product : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public string VideoLink { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }

        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }

        public List<FloorPlan> FloorPlans { get; set; }
    }
}
