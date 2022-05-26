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

namespace InterviewTastApp.Application.Features.HealthChecks.Queries
{
    public class GetHealthCheckHandler : IRequestHandler<GetHealthChecksQuery, Response<HealthCheckDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetHealthCheckHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<HealthCheckDto>> Handle(GetHealthChecksQuery request, CancellationToken cancellationToken)
        {
            var healtcheck = await _unitOfWork.HealthCheckRepository.GetSecondPlace();

            var healcheckDto =_mapper.Map<HealthCheckDto>(healtcheck);

            return new Response<HealthCheckDto>(healcheckDto);
        }
    }
}
