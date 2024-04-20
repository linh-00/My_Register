using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Setores;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.Setores
{
    public class GetSetorByUsuarioUseCase : IGetSetorByUsuarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly ISetorRepository _SetorRepository;
        public readonly IMapper _Mapper;

        public GetSetorByUsuarioUseCase(ILogger logger, ISetorRepository setorRepository, IMapper mapper)
        {
            _Logger = logger;
            _SetorRepository = setorRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<List<SetorDTO>>> Execute(int request)
        {
            var result = new UseCaseResponse<List<SetorDTO>>();

            try
            {
                var Entity = await _SetorRepository.GetSetorByUsuarioAsync(request);

                var  SetorDTO = _Mapper.Map<List<SetorDTO>>(request);

                return result.SetSuccess(SetorDTO);

            }

            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
