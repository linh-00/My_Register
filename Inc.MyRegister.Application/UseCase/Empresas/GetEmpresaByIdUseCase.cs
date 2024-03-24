using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Empresas;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.Empresas
{
    public class GetEmpresaByIdUseCase : IGetEmpresaByIdUseCase
    {
        private readonly ILogger<GetEmpresaByIdUseCase> _logger;
        private readonly IMapper _mapper;
        private readonly IEmpresasRepository _EmpresaRepository;

        public GetEmpresaByIdUseCase(ILogger<GetEmpresaByIdUseCase> logger, IMapper mapper, IEmpresasRepository empresaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _EmpresaRepository = empresaRepository;
        }
        public async Task<UseCaseResponse<EmpresaDTO>> Execute(int request)
        {
            var result = new UseCaseResponse<EmpresaDTO>();
            try
            {
                var Entity = await _EmpresaRepository.GetEmpresasByIdAsync(request);
                var EmpresaDTO = _mapper.Map<EmpresaDTO>(Entity);
                return result.SetSuccess(EmpresaDTO);
            }
            catch (Exception ex)
            {

                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}