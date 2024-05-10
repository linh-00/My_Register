using Inc.MyRegister.DAL.Repositories;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyRegister.IoC.Repositories
{
    public static class RepositoriesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmpresasRepository, EmpresasRepository>();
            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            services.AddScoped<IRegistroPontosRepository, RegistroPontoRepository>();
            services.AddScoped<ISetorRepository, SetoresRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();

            return services;
        }
    }
}
