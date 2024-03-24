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
    public class ListFuncionarioByEmpresaUseCase : IListFuncionarioByEmpresaUseCase
    {
        public readonly ILogger _Logger;
        public readonly IFuncionariosRepository _FuncionariosRepository;
        public readonly IMapper _Mapper;
       
        
        public ListFuncionarioByEmpresaUseCase(IMapper mapper, ILogger<ListFuncionarioByEmpresaUseCase> logger, IFuncionariosRepository funcionariosRepository)
        {
            _Mapper = mapper;
            _Logger = logger;
            _FuncionariosRepository = funcionariosRepository;
        }

        public async Task<UseCaseResponse<List<FuncionarioDTO>>> Execute(int request)
        {
            var result = new UseCaseResponse<List<FuncionarioDTO>>();
            try
            {
                var Entity = await _FuncionariosRepository.GetFuncionariosByEmpresaIdAsync(request);

                var FouncionariosDTO = _Mapper.Map<List<FuncionarioDTO>>(Entity);

                return result.SetSuccess(FouncionariosDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
