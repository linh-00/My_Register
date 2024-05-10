using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.IoC.Mappins;
using Inc.MyRegister.IoC.Repositories;
using Inc.MyRegister.IoC.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyRegister.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyRegisterContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRegister")), ServiceLifetime.Transient);
            services.AddRepositories();
            services.AddUseCases(configuration);
            //services.AddServices(configuration);

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;

        }
    }
}
