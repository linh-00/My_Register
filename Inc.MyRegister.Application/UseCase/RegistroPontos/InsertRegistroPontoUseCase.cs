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
using _RegistroPonto = Inc.MyRegister.Domain.Entities.RegistroPontos;

namespace Inc.MyRegister.Application.UseCase.RegistroPontos
{
    public class InsertRegistroPontoUseCase : IInsertRegistroPontoUseCase
    {
        public readonly ILogger _Logger;
        public readonly IMapper _Mapper;
        public readonly IRegistroPontosRepository _RegistroPontosRepository;

        public InsertRegistroPontoUseCase(ILogger logger, IMapper mapper, IRegistroPontosRepository registroPontosRepository)
        {
            _Logger = logger;
            _Mapper = mapper;
            _RegistroPontosRepository = registroPontosRepository;
        }

        public async Task<UseCaseResponse<RegistroPontoDTO>> Execute(RegistroPontoDTO Request) 
        {
            var result = new UseCaseResponse<RegistroPontoDTO>();
            try
            {
                var Entity = _Mapper.Map<_RegistroPonto>(Request);

                var RegistroPontoDTO = await _RegistroPontosRepository.InsertRegistroPontoRepositoryAsync(Entity);

                var Response = _Mapper.Map<RegistroPontoDTO>(Request);

                return result.SetSuccess(Response);

            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
