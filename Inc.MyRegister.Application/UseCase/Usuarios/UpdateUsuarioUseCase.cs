using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Usuarios;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Usuario = Inc.MyRegister.Domain.Entities.Usuarios;

namespace Inc.MyRegister.Application.UseCase.Usuarios
{
    public class UpdateUsuarioUseCase : IUpdateUsuarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly IUsuariosRepository _UsuariosRepository;
        public readonly IMapper _Mapper;

        public UpdateUsuarioUseCase(ILogger logger, IUsuariosRepository usuariosRepository, IMapper mapper)
        {
            _Logger = logger;
            _UsuariosRepository = usuariosRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<UsuarioDTO>> Execute(UsuarioDTO request)
        {
            var result = new UseCaseResponse<UsuarioDTO>();
            try
            {
                var Entity = _Mapper.Map<_Usuario>(request);
                var UsuarioDTO = await _UsuariosRepository.UpdateUsuariosAsync(Entity);
                var Response = _Mapper.Map<UsuarioDTO>(UsuarioDTO);
                return result.SetSuccess(Response);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
