using Microsoft.AspNetCore.Http;
using Inc.MyRegister.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Inc.MyRegister.Application.Interfaces;
using Inc.MyRegister.Application.Interfaces.Usuarios;
using Inc.MyRegister.Application.DTOs;
using Microsoft.AspNetCore.Authorization;


namespace Inc.MyRegister.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IGetAllUsuarioUseCase _GetAllUsuarioUseCase;
        private readonly IActionResultConverter _ActionResultConverter;
        private readonly IGetUsuarioByIdUseCase _GetUsuarioByIdUseCase;
        private readonly IInsertUsuarioUseCase _InsertUsuarioUseCase;
        private readonly IUpdateUsuarioUseCase _UpdateUsuarioUseCase;

        public UsuarioController(
             IGetAllUsuarioUseCase getAllUsuarioUseCase
            ,IActionResultConverter actionResultConverter
            ,IGetUsuarioByIdUseCase getUsuarioByIdUseCase
            ,IInsertUsuarioUseCase insertUsuarioUseCase
            ,IUpdateUsuarioUseCase updateUsuarioUseCase)
        {
            _ActionResultConverter = actionResultConverter;
            _GetAllUsuarioUseCase = getAllUsuarioUseCase;
            _GetUsuarioByIdUseCase = getUsuarioByIdUseCase;
            _InsertUsuarioUseCase = insertUsuarioUseCase;
            _UpdateUsuarioUseCase = updateUsuarioUseCase;
        }

        [ProducesResponseType(typeof(List<UsuarioDTO>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetAllUsuario()
        {
            var response = await _GetAllUsuarioUseCase.Execute();
            return _ActionResultConverter.Convert(response);
        }

        [ProducesResponseType(typeof(List<UsuarioDTO>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> GetUsuarioById(int IdUsuario)
        {
            var response =  await _GetUsuarioByIdUseCase.Execute(IdUsuario);
            return _ActionResultConverter.Convert(response);
        }

        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> InsertUsuario(UsuarioDTO usuario)
        {
            var response = await _InsertUsuarioUseCase.Execute(usuario);
            return _ActionResultConverter.Convert(response);
        }

        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPut]

        public async Task<IActionResult> UpdateUsuario(UsuarioDTO usuario)
        {
            var response = await _UpdateUsuarioUseCase.Execute(usuario);
            return _ActionResultConverter.Convert(response);
        }

    }
}
