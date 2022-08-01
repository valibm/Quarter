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
    public class SubCatagoryRepository : ISubCatagoryService
    {
        private readonly AppDbContext _context;
        public SubCatagoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SubCatagory> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.SubCatagories.Where(n => n.Id == id)
                                                   .Include(n => n.Catagory)
                                                   .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<SubCatagory>> GetAll()
        {
            var data = await _context.SubCatagories.Include(n => n.Catagory)
                                                   .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(SubCatagory entity)
        {
            await _context.SubCatagories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, SubCatagory entity)
        {
            var data = await Get(id);
            data.Name = entity.Name;
            data.CatagoryId = entity.CatagoryId;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            _context.SubCatagories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
