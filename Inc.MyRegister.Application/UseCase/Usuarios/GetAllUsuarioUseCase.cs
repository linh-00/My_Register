using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Usuarios;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.UseCase.Usuarios
{
    public class GetAllUsuarioUseCase : IGetAllUsuarioUseCase
    {
        public readonly IMapper _Mapper;
        public readonly IUsuariosRepository _UsuariosRepository;
        public readonly ILogger _Logger;

        public GetAllUsuarioUseCase(IMapper mapper, IUsuariosRepository usuariosRepository, ILogger logger)
        {
            _Mapper = mapper;
            _UsuariosRepository = usuariosRepository;
            _Logger = logger;
        }

        public async Task<UseCaseResponse<List<UsuarioDTO>>> Execute()
        {
            var result = new UseCaseResponse<List<UsuarioDTO>>();
            try
            {
                var Entity = await _UsuariosRepository.GetAllUsuariosAsync();
                var UsuariosDTO = _Mapper.Map<List<UsuarioDTO>>(Entity);

                return result.SetSuccess(UsuariosDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
