using InterviewTestApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Features.HealthChecks.Dtos
{
    public class WeatherForecastDto
    {
        public string Date { get; set; }
        public Typeofweatherenum WeatherType { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
    }
}
