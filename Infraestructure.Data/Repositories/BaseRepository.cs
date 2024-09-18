using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Get(id);

            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


        public virtual async Task<T> Get(int id)
        {
            var entity = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.id == id)
                                    .ToListAsync();

            return entity.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>()
                                         .AsNoTracking()
                                         .ToListAsync();

            return entities;
        }
    }
}
