using Application.Features.Auths.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        //Services buraya ekleniyor.Repository(repolar)persistence Katmanına ekleniyor. !!!!!
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AuthBusinessRules>();


            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserService, UserManager>();

            return services;

        }
    }
}
