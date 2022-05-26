using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTastApp.Application.Interfaces.Specifications;
using InterviewTastApp.Application.Models.Paginated;
using InterviewTestApp.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Infrastructure.Persistence.Repositories
{
    public class DbRepository<T> : IDbRepository<T> where T : class
    {
        protected readonly MyDbContext _context;
        public DbRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                               string includeString = null, bool disabledTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disabledTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();

        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                List<Expression<Func<T, object>>> includes = null,
                                                bool disabledTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disabledTracking) query = query.AsNoTracking();

            if (includes != null) query = query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }
        public async Task<EntityList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          List<Expression<Func<T, object>>> includes = null, bool disabledTracking = true, int? page = null, int? pageSize = null
                                         )
        {
            IQueryable<T> query = _context.Set<T>();
            if (disabledTracking) query = query.AsNoTracking();

            if (includes != null) query = query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            int totalCount = query.Count();

            int filteredCount = totalCount;

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            var pageData = await query.ToListAsync();

            if (orderBy != null) await orderBy(query).ToListAsync();

            return new EntityList<T>
            {
                TotalCount = totalCount,
                FilteredCount = filteredCount,
                PageData = pageData,
            };
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await AppliSpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await AppliSpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await AppliSpecification(spec).CountAsync();
        }
        public IQueryable<T> AppliSpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
