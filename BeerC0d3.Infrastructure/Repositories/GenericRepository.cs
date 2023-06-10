using BeerC0d3.Core.Entities;
using BeerC0d3.Infrastructure.Data;
using BeerC0d3.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly BeerCodeContext _context;

        public GenericRepository(BeerCodeContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _context.Set<T>()
        //        .FindAsync(id);
        //}

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .Where(item => item.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }

    }
}
