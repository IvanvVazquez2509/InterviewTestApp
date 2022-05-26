using InterviewTastApp.Application.Interfaces.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace InterviewTestApp.Infrastructure.Persistence.Dapper
{
    public class FactoryConnection : IFactoryConnection
    {
        private IDbConnection _conn;
        private readonly IOptions<ConfigConnection> _config;
        public FactoryConnection(IOptions<ConfigConnection> config)
        {
            _config = config;
        }
        public void CloseConnection()
        {
            if (_conn != null && _conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        public IDbConnection GetConnection()
        {
            if (_conn == null)
            {
                _conn = new SqlConnection(_config.Value.DefaultConnection);
            }
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            return _conn;
        }
    }
}
