using AutoMapper;
using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTestApp.Domain.Entites;

namespace InterviewTastApp.Application.Mappings
{
    public class HealtCheckProfile : Profile
    {
        public HealtCheckProfile()
        {
            CreateMap<HealthCheck, HealthCheckDto>();
        }
    }
}
