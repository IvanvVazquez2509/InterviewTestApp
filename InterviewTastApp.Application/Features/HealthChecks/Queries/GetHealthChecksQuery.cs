using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTastApp.Application.Wrappers;
using MediatR;

namespace InterviewTastApp.Application.Features.HealthChecks.Queries
{
    public class GetHealthChecksQuery : IRequest<Response<HealthCheckDto>>
    {
    }
}
