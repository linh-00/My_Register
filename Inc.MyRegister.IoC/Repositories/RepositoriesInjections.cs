using Inc.MyRegister.DAL.Repositories;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.IoC.Repositories
{
    public class RepositoriesInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmpresasRepository, EmpresasRepository>();
            services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();
            services.AddScoped<IRegistroPontosRepository, RegistroPontoRepository>();
            services.AddScoped<ISetorRepository, SetoresRepository>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        }
}
