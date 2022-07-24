using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IFloorPlansImageService
    {
        public Task Create(FloorPlan floorPlan, Image image);
    }
}
