using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class ProductFeature : IEntity
    {
        public int Id { get; set; }
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
    }
}
