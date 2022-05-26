using InterviewTastApp.Application.Interfaces.Specifications;
using InterviewTastApp.Application.Models.Paginated;
using System.Linq.Expressions;

namespace InterviewTastApp.Application.Interfaces.Persistence
{
    public interface IDbRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disabledTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disabledTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);
        Task<EntityList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                     List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true,
                                     int? page = null, int? pageSize = null);
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
