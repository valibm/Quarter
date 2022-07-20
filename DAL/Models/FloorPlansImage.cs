using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class FloorPlansImage : IEntity
    {
        public int Id { get; set; }
        public int FloorPlanId { get; set; }
        public FloorPlan FloorPlan { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
