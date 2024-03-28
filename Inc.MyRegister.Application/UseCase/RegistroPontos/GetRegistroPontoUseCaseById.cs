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
    public class GetRegistroPontoUseCaseById : IGetRegistroPontosUseCaseById
    {
        public readonly ILogger _Logger;
        public readonly IRegistroPontosRepository _RegistroPontosRepository;
        public readonly IMapper _Mapper;

        GetRegistroPontoUseCaseById(IMapper mapper, ILogger<GetRegistroPontoUseCaseById> logger, IRegistroPontosRepository registroPontosRepository )
        {
            _Mapper = mapper;
            _Logger = logger;
            _RegistroPontosRepository = registroPontosRepository;
        }

        public async Task<UseCaseResponse<RegistroPontoDTO>> Execute(int request) 
        {
            var result = new UseCaseResponse<RegistroPontoDTO>();
            try
            {
                var Entity = await _RegistroPontosRepository.GetRegistroPontosByIdAsync(request);

                var RegistroPontoDTO = _Mapper.Map<RegistroPontoDTO>(Entity);

                return result.SetSuccess(RegistroPontoDTO);
            }
            catch (Exception ex)
            { 
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
