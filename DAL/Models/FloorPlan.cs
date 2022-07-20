using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class FloorPlan : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool PetsAllowed { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<FloorPlansImage> FloorPlansImages { get; set; }

        public List<FloorFeature> FloorFeatures { get; set; }
    }
}
