using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels
{
    public class ProductVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public string VideoLink { get; set; }

        public int AreaId { get; set; }
        public int ProductStatusId { get; set; }

        public double HomeArea { get; set; }
        public int Rooms { get; set; }
        public int Baths { get; set; }
        public int YearBuilt { get; set; }
        public double LotDimensions { get; set; }
        public int Beds { get; set; }
        public double Price { get; set; }

        public double LivingRoom { get; set; }
        public double Garage { get; set; }
        public double DiningArea { get; set; }
        public double Bedroom { get; set; }
        public double Bathroom { get; set; }
        public double GymArea { get; set; }
        public double Garden { get; set; }
        public double Parking { get; set; }

        public List<IFormFile> ImageFiles { get; set; }

        public int AmenityId { get; set; }

        public List<FloorPlan> FloorPlans { get; set; }
        public string AppUserId { get; set; }
    }
}
