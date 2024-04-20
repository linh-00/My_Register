using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.DAL.Repositories;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Funcionario = Inc.MyRegister.Domain.Entities.Funcionarios;

namespace Inc.MyRegister.Application.UseCase.Funcionarios
{
    public class InsertFuncionarioUseCase : IInsertFuncionarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly IMapper _Mapper;
        public readonly IFuncionariosRepository _FuncionariosRepository;

        public InsertFuncionarioUseCase(ILogger logger, IMapper mapper, IFuncionariosRepository funcionariosRepository)
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
                var Entity = _Mapper.Map<_Funcionario>(request);

                var FuncionarioDTO = await _FuncionariosRepository.InsertFuncionariosAsync(Entity);

                var Response = _Mapper.Map<FuncionarioDTO>(request);

                return result.SetSuccess(Response);
            }
            catch(Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        
        }
    }

}
