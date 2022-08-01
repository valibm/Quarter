using Business.Services;
using DAL.Data;
using DAL.Models;
using Exceptions.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class FloorFeatureRepository : IFloorFeatureService
    {
        private readonly AppDbContext _context;
        public FloorFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<FloorFeature> Get(int? id)
        //{
        //    if (id is null)
        //    {
        //        throw new ArgumentNullException(nameof(id));
        //    }

        //    var data = await _context.FloorFeatures.Where(n => n.Id == id)
        //                                           .FirstOrDefaultAsync();

        //    if (data is null)
        //    {
        //        throw new EntityIsNullException();
        //    }

        //    return data;
        //}

        //public async Task<List<FloorFeature>> GetAll()
        //{
        //    var data = await _context.FloorFeatures.ToListAsync();

        //    if (data is null)
        //    {
        //        throw new EntityIsNullException();
        //    }

        //    return data;
        //}

        //public async Task Create(FloorFeature floorFeature)
        //{
        //    await _context.FloorFeatures.AddAsync(floorFeature);
        //    await _context.SaveChangesAsync();
        //}
    }
}
