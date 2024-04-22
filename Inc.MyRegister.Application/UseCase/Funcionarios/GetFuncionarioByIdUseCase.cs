using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Inc.MyRegister.Application.UseCase.Funcionarios
{
    public class GetFuncionarioByIdUseCase : IGetFuncionarioByIdUseCase
    {
        public readonly ILogger _Logger;
        public readonly IFuncionariosRepository _FuncionarioRepository;
        public readonly IMapper _Mapper;

        public GetFuncionarioByIdUseCase(ILogger logger, IFuncionariosRepository funcionarioRepository, IMapper mapper)
        {
            _Logger = logger;
            _FuncionarioRepository = funcionarioRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<FuncionarioDTO>> Execute(int response)
        {
            var result = new UseCaseResponse<FuncionarioDTO>();
            try
            {
                var entity = await _FuncionarioRepository.GetFuncionariosByIdAsync(response);
                var request = _Mapper.Map<FuncionarioDTO>(entity);
                return result.SetSuccess(request);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
