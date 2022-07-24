using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public class FloorPlanImageRepository
    {
        private readonly AppDbContext _context;
        public FloorPlanImageRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}
