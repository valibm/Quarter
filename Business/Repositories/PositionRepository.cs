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
    public class PositionRepository : IPositionService
    {
        private readonly AppDbContext _context;
        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Position> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("Id");
            }

            var entity = await _context.Positions.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new EntityIsNullException();
            }

            return entity;
        }

        public async Task<List<Position>> GetAll()
        {
            var entity = await _context.Positions.ToListAsync();

            if (entity is null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public async Task Create(Position entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("Image");
            }

            await _context.Positions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Position entity)
        {
            var dbEntity = await Get(id);

            if (dbEntity is null)
            {
                throw new NullReferenceException();
            }

            dbEntity.Name = entity.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var entity = await Get(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
