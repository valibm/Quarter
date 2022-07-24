using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IAmenityService
    {
        public Task<SubCatagory> Get(int? id);
        public Task<List<SubCatagory>> GetAll();
    }
}
