using AutoMapper;
using InterviewTastApp.Application.Exceptions;
using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTastApp.Application.Interfaces.Persistence;
using InterviewTastApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Features.WeatherForecast.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<WeatherForecastDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<WeatherForecastDto>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var weather = await _unitOfWork.HealthCheckRepository.GetForecast(request.Id);

            if (weather is null) throw new ApiException("no records");

            var weatherDto = _mapper.Map<WeatherForecastDto>(weather);

            return new Response<WeatherForecastDto>(weatherDto);
        }
    }
}
