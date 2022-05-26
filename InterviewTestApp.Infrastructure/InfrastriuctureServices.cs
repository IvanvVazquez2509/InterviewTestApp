using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTestApp.Infrastructure.Persistence;
using InterviewTestApp.Infrastructure.Persistence.Dapper;
using InterviewTestApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewTestApp.Infrastructure
{
    public static class InfrastriuctureServices
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            //get connection string
            services.AddDbContext<MyDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddOptions();
         //   services.Configure<ConfigConnection>(configuration.GetSection("ConnectionStrings"));
            //Inyeccion de Dapper
            services.AddTransient<IFactoryConnection, FactoryConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //repositories
            services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));

            return services;
        }
    }
}
