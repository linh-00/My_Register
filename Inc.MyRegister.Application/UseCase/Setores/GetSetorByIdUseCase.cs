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
    public class GetSetorByIdUseCase : IGetSetorByIdUseCase
    {
        public readonly ILogger _Logger;
        public readonly ISetorRepository _SetorRepository;
        public readonly IMapper _Mapper;

        public GetSetorByIdUseCase(ILogger logger, ISetorRepository setorRepository, IMapper mapper)
        {
            _Logger = logger;
            _SetorRepository = setorRepository;
            _Mapper = mapper;
        }
        public async Task <UseCaseResponse<SetorDTO>> Execute(int Request)
        {
            var result = new UseCaseResponse<SetorDTO>();
            try 
            {
                var Entity = await _SetorRepository.GetSetoresByIdAsync(Request);
                var SetorDTO = _Mapper.Map<SetorDTO>(Entity);
                return result.SetSuccess(SetorDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
