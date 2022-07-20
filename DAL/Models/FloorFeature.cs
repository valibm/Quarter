using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class FloorFeature : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }

        public int FloorPlanId { get; set; }
        public FloorPlan FloorPlan { get; set; }
    }
}
