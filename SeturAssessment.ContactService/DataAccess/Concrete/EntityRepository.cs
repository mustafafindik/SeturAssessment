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

        public T Get(Expression<Func<T, bool>> predicate)
        {

            return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);

        }

        public T Get(Expression<Func<T, bool>> predicate, params string[] nav)
        {
            var query = _context.Set<T>().AsQueryable();
            return nav.Aggregate(query, (current, n) => current.Include(n)).SingleOrDefault(predicate);

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {

            return predicate == null ? _context.Set<T>().AsNoTracking() : _context.Set<T>().Where(predicate).AsNoTracking();

        }

        public IQueryable<T> GetAll(params string[] nav)
        {

            var query = _context.Set<T>().AsQueryable();
            return nav.Aggregate(query, (current, n) => current.Include(n));
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, params string[] nav)
        {

            var query = predicate == null ? _context.Set<T>() : _context.Set<T>().Where(predicate);
            return nav.Aggregate(query, (current, n) => current.Include(n)).AsNoTracking();

        }

        public void Add(T entity)
        {

            var addedEntityEntry = _context.Entry(entity);
            addedEntityEntry.State = EntityState.Added;
            _context.SaveChanges();

        }

        public void Delete(T entity, S id)
        {
            var existingEntity = _context.Set<T>().Find(id);
            _context.Remove(existingEntity);
            _context.SaveChanges();

        }

        public void Update(T entity,S id)
        {

            var existingEntity = _context.Set<T>().Find(id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();


        }
    }
}