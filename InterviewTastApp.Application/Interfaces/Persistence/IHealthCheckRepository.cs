using InterviewTestApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Interfaces.Persistence
{
    public interface IHealthCheckRepository : IDbRepository<HealthCheck>
    {
        Task<List<WeatherForecast>> GetAllForecasts();
        Task<WeatherForecast> GetForecast(string id);
        Task<HealthCheck> GetSecondPlace();
    }
}
