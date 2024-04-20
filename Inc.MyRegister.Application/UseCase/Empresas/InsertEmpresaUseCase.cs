using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Empresas;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Empresas = Inc.MyRegister.Domain.Entities.Empresas;

namespace Inc.MyRegister.Application.UseCase.Empresas
{
    public class InsertEmpresaUseCase : IInsertEmpresaUseCase
    {
        private readonly ILogger<InsertEmpresaUseCase> _logger;
        private readonly IMapper _mapper;
        private readonly IEmpresasRepository _empresasRepository;

        public InsertEmpresaUseCase(IMapper mapper, IEmpresasRepository empresasRepository, ILogger<InsertEmpresaUseCase> logger)
        {
            _mapper = mapper;
            _empresasRepository = empresasRepository;
            _logger = logger;
        }

        public async Task<UseCaseResponse<EmpresaDTO>> Execute(EmpresaDTO request) 
        {
            var result = new UseCaseResponse<EmpresaDTO>();
            try 
            {
                var Entitys =  _mapper.Map<_Empresas>(request);

                var Insert = await _empresasRepository.InsertEmpresaAsync(Entitys);

                var CustomerDTO = _mapper.Map<EmpresaDTO>(Entitys);

                return result.SetSuccess(CustomerDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
