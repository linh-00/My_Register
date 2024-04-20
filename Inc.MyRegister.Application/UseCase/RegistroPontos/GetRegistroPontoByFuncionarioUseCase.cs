using AutoMapper;
using Azure;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Inc.MyRegister.Application.Interfaces.RegistroPontos;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _RegistroPontos = Inc.MyRegister.Domain.Entities.RegistroPontos;

namespace Inc.MyRegister.Application.UseCase.RegistroPontos
{
    public class GetRegistroPontoByFuncionarioUseCase : IGetRegistroPontoByEmpresaUseCase
    {
        public readonly ILogger _Logger;
        public readonly IRegistroPontosRepository _RegistroPontosRepository;
        public readonly IMapper _Mapper;

        public GetRegistroPontoByFuncionarioUseCase(ILogger<GetRegistroPontoByEmpresaUseCase> logger, IMapper mapper, IRegistroPontosRepository registroPontosRepository)
        {
            _Logger = logger;
            _Mapper = mapper;
            _RegistroPontosRepository = registroPontosRepository;
        }

        public async Task<UseCaseResponse<List<RegistroPontoDTO>>> Execute(int Request)
        {
            var Result = new UseCaseResponse<List<RegistroPontoDTO>>();
            try
            {
                var Entity = _Mapper.Map<_RegistroPontos>(Request);

                return Result.SetSuccess(new List<RegistroPontoDTO>());

            }
            catch (Exception ex)
            {
                return Result.SetInternalServerError(ex.Message);
            }
        }
    }
}
