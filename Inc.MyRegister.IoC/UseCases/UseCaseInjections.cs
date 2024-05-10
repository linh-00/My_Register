using Inc.MyRegister.Application.Interfaces.Empresas;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.Application.UseCase.Empresas;
using Inc.MyRegister.Application.UseCase.Funcionarios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inc.MyRegister.IoC.UseCases
{
    public static class UseCaseInjections
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddScoped<IGetEmpresaByIdUseCase, GetEmpresaByIdUseCase>();
            services.AddScoped<IInsertEmpresaUseCase, InsertEmpresaUseCase>();
            services.AddScoped<IListEmpresaUseCase, ListEmpresaUseCase>();
            services.AddScoped<IUpdateEmpresaUseCase, UpdateEmpresaUseCase>();

            services.AddScoped<IInsertFuncionarioUseCase, InsertFuncionarioUseCase>();

            return services;
        }
    }
}
