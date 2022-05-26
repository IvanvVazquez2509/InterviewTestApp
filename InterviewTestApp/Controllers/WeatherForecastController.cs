using InterviewTastApp.Application.Features.HealthChecks.Dtos;
using InterviewTastApp.Application.Features.HealthChecks.Queries;
using InterviewTastApp.Application.Features.WeatherForecast.GetAll;
using InterviewTastApp.Application.Features.WeatherForecast.GetById;
using InterviewTastApp.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTestApp.Controllers
{

    public class WeatherForecastController : BaseApiController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(Response<WeatherForecastDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(string id)
        {
            var query = new GetByIdQuery();
            query.Id = id;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllWeatherForecasts")]
        [ProducesResponseType(typeof(Response<IEnumerable<WeatherForecastDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllWeatherForecasts()
        {
            var query = new GetAllQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetMessage")]
        [ProducesResponseType(typeof(Response<HealthCheckDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetMessage()
        {
            var query = new GetHealthChecksQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}