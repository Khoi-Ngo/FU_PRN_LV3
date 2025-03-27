using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public static class DependenciesInjection
    {

        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            #region DBContext
     
            #endregion
            services.AddScoped<MainService>();
            services.AddScoped<AccountRepo>();
            services.AddScoped<CosInfoRepo>();
            services.AddScoped<CateRepo>();

            return services;
        }

    }
}
