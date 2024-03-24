using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.Funcionarios
{
    public class GetAllFuncionarioUseCase : IGetAllFuncionarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly IFuncionariosRepository _FuncionariosRepository;
        public readonly IMapper _Mapper;

        public GetAllFuncionarioUseCase(ILogger logger, IFuncionariosRepository funcionariosRepository, IMapper mapper)
        {
            _Logger = logger;
            _FuncionariosRepository = funcionariosRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<List<FuncionarioDTO>>> Execute()
        {
            var result = new UseCaseResponse<List<FuncionarioDTO>>();
            try
            {
                var Entity = await _FuncionariosRepository.GetAllFuncionariosAsync();

                var FuncionarioDTO = _Mapper.Map<List<FuncionarioDTO>>(Entity);

                return result.SetSuccess(FuncionarioDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
