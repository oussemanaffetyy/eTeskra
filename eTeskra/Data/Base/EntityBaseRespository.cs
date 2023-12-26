﻿
using eTeskra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTeskra.Data.Base
{
    public class EntityBaseRespository<T> :IEntityBaseRespository<T> where T : class,IEntityBase , new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRespository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }
            public async Task<T> GetByIdAsync(int id)
            {
                var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }



        public async Task UpdateAsync(int id, T entity)
        {

            EntityEntry entityEntry =  _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
           
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync(); ;
        }
    }
}