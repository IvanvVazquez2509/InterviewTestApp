using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Features.WeatherForecast.GetById
{
    public class GetByIdValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The id shoudn´t be empty")
                              .NotNull().WithMessage("The id shouldn´t be null");
        }
    }
}
