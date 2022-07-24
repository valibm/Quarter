using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public FloorPlansImage FloorPlansImage { get; set; }

        public List<FloorFeature> FloorFeatures { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
