using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class FloorPlanRepository : IFloorPlanService
    {
        private readonly AppDbContext _context;
        public FloorPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FloorPlan> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.FloorPlans.Where(n => n.Id == id)
                                                .Include(n => n.FloorFeatures)
                                                .Include(n => n.FloorPlansImage)
                                                .Include(n => n.Product)
                                                .FirstOrDefaultAsync();             

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<FloorPlan>> GetAll()
        {
            var data = await _context.FloorPlans.Include(n => n.FloorFeatures)
                                                .Include(n => n.FloorPlansImage)
                                                .Include(n => n.Product)
                                                .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(FloorPlan floorPlan)
        {
            await _context.FloorPlans.AddAsync(floorPlan);
            await _context.SaveChangesAsync();
        }
    }
}
