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

namespace Inc.MyRegister.Application.UseCase.Funcionarios
{
    public class GetFuncionarioByIdUseCase : IGetFuncionarioByIdUseCase
    {
        public readonly IMapper _Mapper;
        public readonly ILogger _Logger;
        public readonly IFuncionariosRepository _FuncionarioRepository;

        public GetFuncionarioByIdUseCase(IMapper mapper, ILogger<GetFuncionarioByIdUseCase> logger, IFuncionariosRepository funcionariosRepository)
        {
            _Mapper = mapper;
            _Logger = logger;
            _FuncionarioRepository = funcionariosRepository;
        }

        public async Task<UseCaseResponse<FuncionarioDTO>> Execute(int request)
        {
            var result = new UseCaseResponse<FuncionarioDTO>();
            try
            {
                var Entity = await _FuncionarioRepository.GetFuncionariosByIdAsync(request);
                var FuncionarioDTO = _Mapper.Map<FuncionarioDTO>(Entity);
                return result.SetSuccess(FuncionarioDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }


        }
    }
}
