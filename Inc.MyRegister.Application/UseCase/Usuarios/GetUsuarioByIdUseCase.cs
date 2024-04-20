using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Usuarios;
using Inc.MyRegister.DAL.Repositories;
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
    public class GetUsuarioByIdUseCase : IGetUsuarioByIdUseCase
    {
        public readonly ILogger _Logger;
        public readonly IUsuariosRepository _UsuarioRepository;
        public readonly IMapper _Mapper;

        public GetUsuarioByIdUseCase(ILogger logger, IUsuariosRepository usuarioRepository, IMapper mapper)
        {
            _Logger = logger;
            _UsuarioRepository = usuarioRepository;
            _Mapper = mapper;
        }

        public async Task<UseCaseResponse<UsuarioDTO>>Execute(int request)
        {
            var result = new UseCaseResponse<UsuarioDTO>();
            try
            {
                var Entity = await _UsuarioRepository.GetUsuariosByIdAsync(request);
                var UsuarioDTO = _Mapper.Map<UsuarioDTO>(Entity);
                return result.SetSuccess(UsuarioDTO);
            }
            catch (Exception ex)
            {
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
