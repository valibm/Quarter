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
    public class CatagoryRepository : ICatagoryService
    {
        private readonly AppDbContext _context;
        public CatagoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Catagory> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var data = await _context.Catagories.Where(n => n.Id == id)
                                                .Include(n => n.SubCatagories)
                                                .FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task<List<Catagory>> GetAll()
        {
            var data = await _context.Catagories.Include(n => n.SubCatagories)
                                                .ToListAsync();

            if (data is null)
            {
                throw new EntityIsNullException();
            }

            return data;
        }

        public async Task Create(Catagory entity)
        {
            await _context.Catagories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Catagory entity)
        {
            var data = await Get(id);
            data.Name = entity.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);
            _context.Catagories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
