using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Usuarios;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Usuario = Inc.MyRegister.Domain.Entities.Usuarios;

namespace Inc.MyRegister.Application.UseCase.Usuarios
{
    public class InsertUsuarioUseCase : IInsertUsuarioUseCase
    {
        public readonly ILogger _Logger;
        public readonly IUsuariosRepository _UsuarioRepository;
        public readonly IMapper _Mapper;

        public InsertUsuarioUseCase(ILogger logger, IUsuariosRepository usuarioRepository, IMapper mapper)
        {
            _Logger = logger;
            _UsuarioRepository = usuarioRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<UsuarioDTO>> Execute(UsuarioDTO request)
        {
            var result = new UseCaseResponse<UsuarioDTO>();

            try
            {
                var Entity = _Mapper.Map<_Usuario>(request);

                var Insert = _UsuarioRepository.InsertUsuariosAsync(Entity);

                var UsuarioDTO = _Mapper.Map<UsuarioDTO>(Insert);

                return result.SetSuccess(UsuarioDTO);

            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
