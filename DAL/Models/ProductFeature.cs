using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductFeature : IEntity
    {
        public int Id { get; set; }
        public double LivingRoom { get; set; }
        public double Garage { get; set; }
        public double DiningArea { get; set; }
        public double Bedroom { get; set; }
        public double Bathroom { get; set; }
        public double GymArea { get; set; }
        public double Garden { get; set; }
        public double Parking { get; set; }
    }
}
