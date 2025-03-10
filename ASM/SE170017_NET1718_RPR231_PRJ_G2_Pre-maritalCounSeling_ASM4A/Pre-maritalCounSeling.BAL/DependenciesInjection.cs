using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pre_maritalCounSeling.BAL.Auth;
using Pre_maritalCounSeling.BAL.ServiceQuiz;
using Pre_maritalCounSeling.BAL.ServiceUser;
using Pre_maritalCounSeling.DAL.Entities;
using Pre_maritalCounSeling.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_maritalCounSeling.BAL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            #region DBContext
            services.AddDbContext<NET1718_PRN231_PRJ_G2_PremaritalCounselingContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            #endregion

            #region BAL Services

            //JWT service
            services.AddScoped<JWTService>();

            services.AddScoped<IQuizResultService, QuizResultService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            //UnitOfWork
            services.AddScoped<UnitOfWork>();
            return services;
        }
    }
}
