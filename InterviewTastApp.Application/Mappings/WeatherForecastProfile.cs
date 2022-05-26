using AutoMapper;
using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTestApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Mappings
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>();
        }
    }
}
