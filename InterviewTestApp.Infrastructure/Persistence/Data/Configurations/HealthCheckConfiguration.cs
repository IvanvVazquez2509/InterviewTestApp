using InterviewTestApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewTestApp.Infrastructure.Persistence.Data.Configurations
{
    public class HealthCheckConfiguration : IEntityTypeConfiguration<HealthCheck>
    {
        public void Configure(EntityTypeBuilder<HealthCheck> builder)
        {
            builder.ToTable("healthCheck");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Message).HasColumnName("message");


            builder.HasData(new HealthCheck { Id = 1, Message = "OH NO!" },
                new HealthCheck { Id = 2, Message = "Everything is OK!" });
        }
    }
}
