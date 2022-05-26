using InterviewTestApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Infrastructure.Persistence.Data.Configurations
{
    public class LstWeatherTypeConfiguration : IEntityTypeConfiguration<LstWeatherType>
    {
        public void Configure(EntityTypeBuilder<LstWeatherType> builder)
        {
            builder.ToTable("lstWeatherType");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            builder.HasData(new LstWeatherType { Id = 1, Type = "Rain" },
                new LstWeatherType { Id = 2, Type = "Snow" },
                new LstWeatherType { Id = 3, Type = "Sun" });
        }
    }
}
