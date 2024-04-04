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
using _Setor = Inc.MyRegister.Domain.Entities.Setores;

namespace Inc.MyRegister.Application.UseCase.Setores
{
    public class InsertSetorUseCase : IInsertSetorUseCase
    {
        public readonly ILogger _Logger;
        public readonly ISetorRepository _SetorRepository;
        public readonly IMapper _Mapper;

        public InsertSetorUseCase(ILogger logger, ISetorRepository setorRepository, IMapper mapper)
        {
            _Logger = logger;
            _SetorRepository = setorRepository;
            _Mapper = mapper;
        }
        public async Task<UseCaseResponse<SetorDTO>> Execute(SetorDTO request)
        {
            var result = new UseCaseResponse<SetorDTO>();
            try 
            {
                var Entity = _Mapper.Map<_Setor>(request);

                var Insert = _SetorRepository.InsertSetoresAsync(Entity);

                var SetorDTO = _Mapper.Map<SetorDTO>(Insert);

                return result.SetSuccess(SetorDTO);
            }

            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
