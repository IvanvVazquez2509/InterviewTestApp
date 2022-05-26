using FluentValidation;
using InterviewTastApp.Application.Behaviours;
using InterviewTastApp.Application.Interfaces;
using InterviewTastApp.Application.Interfaces.Services;
using InterviewTastApp.Application.Services;
using InterviewTastApp.Application.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
            // services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
            services.AddScoped<IValidateEntites, ValidateEntities>();
            return services;
        }
    }
}
