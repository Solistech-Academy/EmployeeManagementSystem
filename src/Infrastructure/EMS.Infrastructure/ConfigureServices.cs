using EMS.Application.Common.Interfaces;
using EMS.Domain.Repositories.Command;
using EMS.Domain.Repositories.Command.Base;
using EMS.Domain.Repositories.Query;
using EMS.Domain.Repositories.Query.Base;
using EMS.Infrastructure.Data;
using EMS.Infrastructure.Repositories.Command;
using EMS.Infrastructure.Repositories.Command.Base;
using EMS.Infrastructure.Repositories.Query;
using EMS.Infrastructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddEMSInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EMSContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IEMSContext>(provider => provider.GetRequiredService<EMSContext>());
            services.AddTransient<EMSContextInitialiser>();

            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));

            services.AddTransient<IEmployeeQueryRepository, EmployeeQueryRepository>();
            services.AddTransient<IDepartmentQueryRepository, DepartmentQueryRepository>();

            services.AddTransient<IEmployeeDepartmentQueryRepository, EmployeeDepartmentQueryRepository>();
            services.AddTransient<IEmployeeCommandRepository, EmployeeCommandRepository>();

            services.AddTransient<IDepartmentCommandRepository, DepartmentCommandRepository>();
            services.AddTransient<IEmployeeDepartmentCommandRepository, EmployeeDepartmentCommandRepository>();


            return services;
        }

    }
}
