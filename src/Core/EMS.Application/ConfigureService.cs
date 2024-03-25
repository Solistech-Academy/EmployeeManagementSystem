using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EMS.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection AddEMSApplicationServices(this IServiceCollection services)
        {
            //register fluent validations
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
