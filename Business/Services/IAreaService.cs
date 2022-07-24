using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAreaService
    {
        public Task<Area> Get(int? id);
        public Task<List<Area>> GetAll();
        public Task Create(Area area);
    }
}
