using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeturAssessment.ContactService.DataAccess.Abstract;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.DataAccess.Concrete
{
    public class EntityRepository<T,S, TContext> : IEntityRepository<T,S> where T : class, IEntity, new() where TContext : DbContext // T:Sınıf,IentityImplementEden,Newlenebilir | TContext :DbContext inherit eden
    {
        private readonly TContext _context;
        public EntityRepository(TContext context)
        {
            _context = context;
        }


        public async  Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] nav)
        {
            var query =  _context.Set<T>().AsQueryable();
            return await nav.Aggregate(query, (current, n) => current.Include(n)).SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await (predicate == null
                ? _context.Set<T>().AsNoTracking().ToListAsync()
                : _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync());
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] nav)
        {
             var query = _context.Set<T>().AsQueryable();
            return await (nav.Aggregate(query, (current, n) => current.Include(n)).ToListAsync());
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params string[] nav)
        {
            var query = (predicate == null ? _context.Set<T>() : _context.Set<T>().Where(predicate));
            return await (nav.Aggregate(query, (current, n) => current.Include(n)).AsNoTracking().ToListAsync());
        }

        public async Task AddAsync(T entity)
        {
            var addedEntityEntry = _context.Entry(entity);
            addedEntityEntry.State = EntityState.Added;
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(S id)
        {
            var existingEntity = await _context.Set<T>().FindAsync(id); 
            _context.Remove(existingEntity);
            await  _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, S id)
        {
            var existingEntity =await _context.Set<T>().FindAsync(id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}