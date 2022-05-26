using AutoMapper;
using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTastApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Features.WeatherForecast.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, Response<IEnumerable<WeatherForecastDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<WeatherForecastDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var weatherForecast = await _unitOfWork.HealthCheckRepository.GetAllForecasts();

            var weatherForecastDto = _mapper.Map<IEnumerable< WeatherForecastDto>>(weatherForecast);

            return new Response<IEnumerable<WeatherForecastDto>>(weatherForecastDto);
        }
    }
}
