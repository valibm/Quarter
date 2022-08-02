using DAL.Base;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Product : BaseEntity, IEntity
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Description { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string SubDescription { get; set; }
        [DataType(DataType.Url)]
        public string VideoLink { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int ProductFeatureId { get; set; }
        public ProductFeature ProductFeature { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSubCatagory> ProductSubCatagories { get; set; }

        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }

        public List<FloorPlan> FloorPlans { get; set; }

        public int ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public IFormFile CardFile { get; set; }
        [NotMapped]
        public List<IFormFile> HeaderFiles { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
