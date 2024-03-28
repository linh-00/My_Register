using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.RegistroPontos;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.RegistroPontos
{
    public class GetRegistroPontoByEmpresaUseCase : IGetRegistroPontoByEmpresaUseCase
    {
        public readonly IMapper _Mapper;
        public readonly IRegistroPontosRepository _RegistroPontosRepository;
        public readonly ILogger _Logger;

        public  GetRegistroPontoByEmpresaUseCase(IMapper mapper, ILogger<GetRegistroPontoByEmpresaUseCase> logger, IRegistroPontosRepository registroPontosRepositoryd)
        {
            _Logger = logger;
            _Mapper = mapper;
            _RegistroPontosRepository = registroPontosRepositoryd;
        }

        public async Task<UseCaseResponse<List<RegistroPontoDTO>>> Execute(int Request)
        {
            var Result = new UseCaseResponse<List<RegistroPontoDTO>>();

            try
            {
                var Entity = await _RegistroPontosRepository.GetRegistroPontoByEmpresaAsync(Request);
                var RegistroPontosDTO = _Mapper.Map<List<RegistroPontoDTO>>(Entity);
                return Result.SetSuccess(RegistroPontosDTO);

            }
            catch (Exception ex)
            {
                return Result.SetInternalServerError(ex.Message);
            }
        }        
    }
}
