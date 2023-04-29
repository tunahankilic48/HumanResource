using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HumanResource.Domain.Repositries
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task Create(TEntity entitiy);

        Task Update(TEntity entitiy);

        Task Delete(TEntity entitiy); 

        Task<bool> Any(Expression<Func<TEntity, bool>> expression); 
        Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression); 
        Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression); 

        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );

        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<TEntity, TResult>> select,
            Expression<Func<TEntity, bool>> where,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );
    }
}
