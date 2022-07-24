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

        public string FeatureName { get; set; }
        public double FeatureSize { get; set; }

        public List<IFormFile> ImageFiles { get; set; }

        public int AmenityId { get; set; }
    }
}
