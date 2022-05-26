using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDapperRepository DapperRepository { get; }
        IHealthCheckRepository HealthCheckRepository { get; }
        IDbRepository<TEntity> DbRepository<TEntity>() where TEntity : class;
    }
}
