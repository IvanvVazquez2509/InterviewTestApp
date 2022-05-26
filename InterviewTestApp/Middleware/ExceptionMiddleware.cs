using InterviewTastApp.Application.Exceptions;
using InterviewTastApp.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace InterviewTestApp.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Succeded = false,
                    Message = ex?.Message
                };

                //    var statusCode = (int)HttpStatusCode.InternalServerError;


                switch (ex)
                {
                    case NotFoundException notFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case ValidationException validationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = validationException.Errors;

                        break;

                    case ApiException apiException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await context.Response.WriteAsync(result);

            }

        }
    }
}
