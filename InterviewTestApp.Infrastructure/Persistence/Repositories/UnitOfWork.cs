using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTestApp.Infrastructure.Persistence.Dapper;
using System.Collections;

namespace InterviewTestApp.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly MyDbContext _context;
        private readonly IFactoryConnection _factoryConnection;


        private readonly IDapperRepository _dapperRepository;
        private readonly IHealthCheckRepository _healthCheckRepository;
        public UnitOfWork(MyDbContext context, IFactoryConnection factoryConnection)
        {
            _context = context;
            _factoryConnection = factoryConnection;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IDbRepository<TEntity> DbRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(DbRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IDbRepository<TEntity>)_repositories[type];
        }
        //add the new repositories
        public IDapperRepository DapperRepository => _dapperRepository ?? new DapperRepository(_factoryConnection);
         public IHealthCheckRepository HealthCheckRepository => _healthCheckRepository ?? new HealthCheckRepository(_context);
        public async Task<int> save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
