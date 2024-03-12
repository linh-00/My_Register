using Inc.MyRegister.DAL.Context;
using Inc.MyRegister.IoC.Mappins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.IoC
{
    public class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<dbMyRegisterContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRegister")), ServiceLifetime.Transient);
            services.AddRepositories(configuration);
            services.AddUseCases(configuration);
            //services.AddServices(configuration);


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services; services.AddRepositories(configuration);
            services.AddUseCases(configuration);
            //services.AddServices(configuration);


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;

        }
    }
}
