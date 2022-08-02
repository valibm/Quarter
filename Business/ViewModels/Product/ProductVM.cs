using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.ViewModels
{
    public class ProductVM
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
        public int ProductStatusId { get; set; }

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
        [Required, Range(1, 50)]
        public double Price { get; set; }

        [Required, Range(1, 500)]
        public double LivingRoom { get; set; }
        [Required, Range(1, 500)]
        public double Garage { get; set; }
        [Required, Range(1, 500)]
        public double DiningArea { get; set; }
        [Required, Range(1, 500)]
        public double Bedroom { get; set; }
        [Required, Range(1, 500)]
        public double Bathroom { get; set; }
        [Required, Range(1, 500)]
        public double GymArea { get; set; }
        [Required, Range(1, 500)]
        public double Garden { get; set; }
        [Required, Range(1, 500)]
        public double Parking { get; set; }

        public List<IFormFile> ImageFiles { get; set; }

        public int AmenityId { get; set; }

        public List<FloorPlan> FloorPlans { get; set; }
        public string AppUserId { get; set; }
    }
}
