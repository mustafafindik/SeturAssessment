using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.DataAccess.Abstract
{
    public interface IEntityRepository<T,S> where T : class, IEntity, new() //Sınıf , IEntity implement Eden ve newlenebilen sınıflar sadece
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] nav);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllAsync(params string[] nav);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params string[] nav);
        Task AddAsync(T entity);
        Task DeleteAsync(S id);
        Task UpdateAsync(T entity, S id);
    }
}
