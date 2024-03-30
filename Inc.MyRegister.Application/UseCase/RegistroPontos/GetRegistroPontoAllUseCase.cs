using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.RegistroPontos;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Interface;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.RegistroPontos
{
    public class GetRegistroPontoAllUseCase : IGetRegistroPontoAllUseCase
    {
        public readonly ILogger _Logger;
        public readonly IRegistroPontosRepository _RegistroPontosRepository;
        public readonly IMapper _Mapper;

        public GetRegistroPontoAllUseCase(ILogger logger, IRegistroPontosRepository registroPontosRepository, IMapper mapper)
        {
            _Logger = logger;
            _RegistroPontosRepository = registroPontosRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<List<RegistroPontoDTO>>> Execute()
        {
            var result = new UseCaseResponse<List<RegistroPontoDTO>>();
            try
            {
                var entity = await _RegistroPontosRepository.GetAllRegistroPontosAsync();
                var RegistroPontoDTO = _Mapper.Map<List<RegistroPontoDTO>>(entity);
                return result.SetSuccess(RegistroPontoDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }

    }
}
