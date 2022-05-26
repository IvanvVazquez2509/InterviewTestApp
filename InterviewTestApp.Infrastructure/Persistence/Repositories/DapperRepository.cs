using Dapper;
using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTestApp.Infrastructure.Persistence.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Infrastructure.Persistence.Repositories
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IFactoryConnection _connection;

        public DapperRepository(IFactoryConnection connection)
        {
            _connection = connection;
        }

        public Task<int> Execute(string sp, DynamicParameters parms)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(string sp, DynamicParameters parms)
        {
            T result;
            try
            {
                var con = _connection.GetConnection();
                result = await con.QueryFirstOrDefaultAsync<T>(sp, parms, commandType: CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw new Exception("Error en la consulta");
            }
            finally
            {
                _connection.CloseConnection();
            }
            return result;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string sp, DynamicParameters parms)
        {
            IEnumerable<T> results = null;
            try
            {
                var conn = _connection.GetConnection();
                results = await conn.QueryAsync<T>(sp, parms, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("error en la conuslta", e);
            }
            finally
            {
                _connection.CloseConnection();
            }
            return results;
        }

        public async Task Insert(string sp, DynamicParameters parms)
        {

            try
            {
                var con = _connection.GetConnection();
                await con.ExecuteAsync(sp, parms, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {

                throw new Exception("Error en la consulta", e);
            }
            finally
            {
                _connection.CloseConnection();
            }

        }

        public async Task Update(string sp, DynamicParameters parms)
        {
            try
            {
                var con = _connection.GetConnection();
                await con.ExecuteAsync(sp, parms, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {

                throw new Exception("No se pudo editar la información", e);
            }
            finally
            {
                _connection.CloseConnection();
            }
        }



        public async Task<T> InsertWithResult<T>(string sp, DynamicParameters parms)
        {
            T result;
            try
            {
                var con = _connection.GetConnection();
                result = await con.QuerySingleAsync<T>(sp, parms, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {

                throw new Exception("No se pudo editar la información", e);
            }
            finally
            {
                _connection.CloseConnection();
            }
            return result;
        }

        public async Task<IEnumerable<T>> InsertWithResults<T>(string sp, DynamicParameters parms)
        {
            IEnumerable<T> results;
            try
            {
                var con = _connection.GetConnection();
                results = await con.QueryAsync<T>(sp, parms, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {

                throw new Exception("No se pudo editar la información", e);
            }
            finally
            {
                _connection.CloseConnection();
            }
            return results;
        }
    }
}
