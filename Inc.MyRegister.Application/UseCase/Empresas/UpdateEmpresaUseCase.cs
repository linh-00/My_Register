using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Empresas;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Empresa = Inc.MyRegister.Domain.Entities.Empresas;

namespace Inc.MyRegister.Application.UseCase.Empresas
{
    public class UpdateEmpresaUseCase : IUpdateEmpresaUseCase
    {
        public readonly ILogger _logger;
        public readonly IMapper _mapper;
        public readonly IEmpresasRepository _empresasRepository;

        public UpdateEmpresaUseCase(ILogger <UpdateEmpresaUseCase>logger, IMapper mapper, IEmpresasRepository empresasRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _empresasRepository = empresasRepository;
        }

        public async Task <UseCaseResponse<EmpresaDTO>> Execute(EmpresaDTO request)
        {
            var result = new UseCaseResponse<EmpresaDTO>();

            try
            {
                var Entity = _mapper.Map<_Empresa>(request);

                var EmpresaEntity = await _empresasRepository.UpdateEmpresasAsync(Entity);

                var EmpresaDTO = _mapper.Map<EmpresaDTO>(EmpresaEntity);

                return result.SetSuccess(EmpresaDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
            
    }
}
