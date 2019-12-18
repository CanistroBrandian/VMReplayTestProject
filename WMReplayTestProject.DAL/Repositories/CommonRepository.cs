using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WMReplayTestProject.DAL.Context;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.DAL.Repositories
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {

        protected readonly EFContext _context;

        public CommonRepository(EFContext context)
        {
            _context = context;
        }
        public virtual async Task CreateAsync(T item)
        {
            if (item == null) throw new Exception("Значения модели не описаны");
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
           
        }

        public virtual async Task DeleteAsync(int id)
        {
            var dbEntry = await _context.Set<T>().FindAsync(id);
            if (dbEntry == null) throw new Exception("Значения модели не описаны");
            _context.Remove(dbEntry);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _context.Set<T>()
                    .AsNoTracking()
                    .Where(predicate)
                    .ToListAsync();
            }
            return await _context.Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
        }

        public virtual async Task UpdateAsync(T item)
        {
            var exist = await _context.Set<T>().FindAsync(item.Id);
            _context.Entry(exist).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }


    }
}
