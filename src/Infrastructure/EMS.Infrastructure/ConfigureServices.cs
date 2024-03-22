using EMS.Application.Common.Interfaces;
using EMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddEMSInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EMSContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IEMSContext>(provider => provider.GetRequiredService<EMSContext>());

            return services;
        }
      
    }
}
