using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IFloorPlanService
    {
        public Task<FloorPlan> Get(int? id);
        public Task<List<FloorPlan>> GetAll();
        public Task Create(FloorPlan floorPlan);
    }
}
