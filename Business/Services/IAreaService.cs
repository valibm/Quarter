using Business.Base;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAreaService : IBaseService<Area>
    {
        public Task<List<Area>> GetForHome();
        public Task<Area> GetForArea(int? id);
    }
}
