using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTestApp.Domain.Entites;
using InterviewTestApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp.Infrastructure.Persistence.Repositories
{
    public class HealthCheckRepository : DbRepository<HealthCheck>, IHealthCheckRepository
    {
        public HealthCheckRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<HealthCheck> GetSecondPlace()
        {
            var healthCheckMessage = await _context.HealthChecks
                .Select(c => new HealthCheck
                {
                    Id = c.Id,
                    Message = c.Message
                }).Skip(1).FirstOrDefaultAsync();

            return healthCheckMessage;

        }
        public async Task<List<WeatherForecast>> GetAllForecasts()
        {
            var items = await _context.WeatherForecasts.Include(x => x.WeatherType).ToListAsync();
            var output = new List<WeatherForecast>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                output.Add(new WeatherForecast
                {
                    Date = item.Date.ToString(),
                    Summary = item.Description.ToString(),
                    TemperatureC = (int)item.TemperatureCelseus,
                    TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                    WeatherType = (Typeofweatherenum)item.WeatherType.Id
                });
            }
            return output;
        }

        public async Task<WeatherForecast> GetForecast(string id)
        {
            var items = await _context.WeatherForecasts.Include(x => x.WeatherType).ToListAsync();
            var output = new List<WeatherForecast>();
            WeatherForecast singleOutput = new WeatherForecast();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                output.Add(new WeatherForecast
                {
                    Date = item.Date.ToString(),
                    Summary = item.Description.ToString(),
                    TemperatureC = (int)item.TemperatureCelseus,
                    TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                    WeatherType = (Typeofweatherenum)item.WeatherType.Id
                });
                if (item.Id == Guid.Parse(id))
                {
                    singleOutput = new WeatherForecast
                    {
                        Date = item.Date.ToString(),
                        Summary = item.Description.ToString(),
                        TemperatureC = (int)item.TemperatureCelseus,
                        TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                        WeatherType = (Typeofweatherenum)item.WeatherType.Id
                    };
                }
            }
            return singleOutput;
        }
    }
}
