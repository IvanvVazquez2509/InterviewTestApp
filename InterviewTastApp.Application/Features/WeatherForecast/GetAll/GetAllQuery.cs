using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTastApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Features.WeatherForecast.GetAll
{
    public class GetAllQuery : IRequest<Response<IEnumerable<WeatherForecastDto>>>
    {
    }
}
