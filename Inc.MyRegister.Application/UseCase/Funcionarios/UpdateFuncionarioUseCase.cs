using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Funcionarios = Inc.MyRegister.Domain.Entities.Funcionarios;

namespace Inc.MyRegister.Application.UseCase.Funcionarios
{
    public class UpdateFuncionarioUseCase : IUpdateFuncionarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly IFuncionariosRepository _FuncionariosRepository;
        public readonly IMapper _Mapper;

        public UpdateFuncionarioUseCase(ILogger logger, IFuncionariosRepository funcionariosRepository, IMapper mapper)
        {
            _Logger = logger;
            _FuncionariosRepository = funcionariosRepository;
            _Mapper = mapper;
        }
        public async Task<UseCaseResponse<FuncionarioDTO>> Execute(FuncionarioDTO request)
        {
            var result = new UseCaseResponse<FuncionarioDTO>();
            try
            {
                var Entity = _Mapper.Map<_Funcionarios>(request);

                var Funcionarios = await _FuncionariosRepository.GetAllFuncionariosAsync();

                var FuncionariosDTO = _Mapper.Map<FuncionarioDTO>(request);

                return result.SetSuccess(FuncionariosDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
