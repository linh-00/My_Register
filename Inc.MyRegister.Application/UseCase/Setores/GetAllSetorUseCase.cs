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
    public class GetAllSetorUseCase : IGetAllSetorUseCase
    {
        public readonly ILogger _Logger;
        public readonly ISetorRepository _SetoresRepository;
        public readonly IMapper _Mapper;

        public GetAllSetorUseCase(ILogger<GetAllSetorUseCase> logger, ISetorRepository setoresRepository, IMapper mapper)
        {
            _Logger = logger;
            _SetoresRepository = setoresRepository;
            _Mapper = mapper;
        }
         
        public async Task<UseCaseResponse<List<SetorDTO>>> Execute()
        {
            var result = new UseCaseResponse<List<SetorDTO>>();
            try
            {
                var Entity = await _SetoresRepository.GetAllSetoresAsync();

                var SetorDTO = _Mapper.Map<List<SetorDTO>>(Entity);

                return result.SetSuccess(SetorDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
