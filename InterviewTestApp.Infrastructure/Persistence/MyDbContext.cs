using InterviewTestApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InterviewTestApp.Infrastructure.Persistence
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated(); // DO NOT REMOVE. Needed to seed database.
        }

        public virtual DbSet<HealthCheck> HealthChecks { get; set; }
        public virtual DbSet<LstWeatherType> LstWeatherTypes { get; set; } = null!;
        public virtual DbSet<TableWeatherForecast> WeatherForecasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
