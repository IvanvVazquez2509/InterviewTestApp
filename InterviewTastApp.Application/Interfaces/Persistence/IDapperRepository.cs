using Dapper;

namespace InterviewTastApp.Application.Interfaces.Persistence
{
    public interface IDapperRepository
    {
        Task<T> Get<T>(string sp, DynamicParameters parms);
        Task<IEnumerable<T>> GetAll<T>(string sp, DynamicParameters parms);
        Task<int> Execute(string sp, DynamicParameters parms);
        Task Insert(string sp, DynamicParameters parms);
        Task Update(string sp, DynamicParameters parms);
        Task<T> InsertWithResult<T>(string sp, DynamicParameters parms);
        Task<IEnumerable<T>> InsertWithResults<T>(string sp, DynamicParameters parms);
    }
}
