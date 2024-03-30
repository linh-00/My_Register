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
using _RegistroPonto = Inc.MyRegister.Domain.Entities.RegistroPontos;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.RegistroPontos
{
    public class UpdateRegistroPontoUseCasa : IUpdateRegistroPontoUseCase
    {
        public readonly ILogger _Logger;
        public readonly IRegistroPontosRepository _RegistroPontoRepositoy;
        public readonly IMapper _Mapper;

        public UpdateRegistroPontoUseCasa(ILogger<UpdateRegistroPontoUseCasa> logger, IMapper mapper, IRegistroPontosRepository registroPontosRepository)
        {
            _Logger = logger;
            _Mapper = mapper;
            _RegistroPontoRepositoy = registroPontosRepository;
        }

        public async Task<UseCaseResponse<RegistroPontoDTO>> Execute(RegistroPontoDTO request)
        {
            var result = new UseCaseResponse<RegistroPontoDTO>();
            try
            {
                var Entity = _Mapper.Map<_RegistroPonto>(request);
                var RegistroPontoDTO = await _RegistroPontoRepositoy.UpdateRegistroPontoAsync(Entity);
                var Response = _Mapper.Map<RegistroPontoDTO>(RegistroPontoDTO);
                return result.SetSuccess(Response);

            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
