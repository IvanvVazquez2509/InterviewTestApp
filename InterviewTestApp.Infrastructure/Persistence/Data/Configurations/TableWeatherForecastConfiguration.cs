using InterviewTestApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Infrastructure.Persistence.Data.Configurations
{
    public class TableWeatherForecastConfiguration : IEntityTypeConfiguration<TableWeatherForecast>
    {
        public void Configure(EntityTypeBuilder<TableWeatherForecast> builder)
        {
            builder.ToTable("weatherForecast");
            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Date)
                .HasColumnName("date");
            builder.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            builder.Property(e => e.TemperatureCelseus)
                .HasColumnName("tempc");
            builder.HasOne(e => e.WeatherType)
                .WithMany(w => w.WeatherForecasts)
                .HasForeignKey(x => x.WeatherTypeId);

             builder.HasData(new TableWeatherForecast { Id = Guid.Parse("c2c72824-3313-483b-8648-002ebd14c90e"), Date = DateTime.Now, Description = "Dreary Weather!", TemperatureCelseus = 20, WeatherTypeId = 1 },
                new TableWeatherForecast { Id = Guid.Parse("cf25592f-8fa4-4ec4-b0da-cf5c120e8cc4"), Date = DateTime.Now, Description = "Cold Weather!", TemperatureCelseus = 5, WeatherTypeId = 2 },
                new TableWeatherForecast { Id = Guid.Parse("3f9cd820-0750-4237-8fb9-263cfebe7c84"), Date = DateTime.Now, Description = "Hot Weather!", TemperatureCelseus = 40, WeatherTypeId = 3 });
        }
    }
}
