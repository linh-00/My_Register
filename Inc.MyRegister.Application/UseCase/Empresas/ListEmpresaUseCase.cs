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

namespace Inc.MyRegister.Application.UseCase.Empresas
{
    public class ListEmpresaUseCase : IListEmpresaUseCase
    {
        public readonly ILogger<ListEmpresaUseCase> _logger;
        public readonly IMapper _mapper;
        public readonly IEmpresasRepository _empresasRepository;

        public ListEmpresaUseCase(ILogger<ListEmpresaUseCase> logger, IMapper mapper, IEmpresasRepository empresasRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _empresasRepository = empresasRepository;
        }

        public async Task<UseCaseResponse<List<EmpresaDTO>>> Execute()
        {
            var result = new UseCaseResponse<List<EmpresaDTO>>();

            try
            {
                var Entity = await _empresasRepository.GetEmpresasAsync();

                var EmpresaDTO = _mapper.Map<List<EmpresaDTO>>(Entity);

                return result.SetSuccess(EmpresaDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
