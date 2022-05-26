using System.Data;

namespace InterviewTastApp.Application.Interfaces.Persistence
{
    public interface IFactoryConnection
    {
        void CloseConnection();
        IDbConnection GetConnection();
    }
}
