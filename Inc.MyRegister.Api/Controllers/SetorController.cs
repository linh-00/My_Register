using Inc.MyRegister.Api.Interfaces;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Setores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyRegister.Api.Controllers
{
    [ApiController]
    [Route("api/v4/[controller]")]
    public class SetorController : ControllerBase
    {
        public readonly IGetAllSetorUseCase _GetAllSetorUseCase;
        public readonly IActionResultConverter _ActionResultConverter;
        public readonly IGetSetorByEmpresaUseCase _GetSetorByEmpresaUseCase;
        public readonly IGetSetorByFuncionarioUseCase _GetSetorByFuncionarioUseCase;
        public readonly IGetSetorByUsuarioUseCase _GetSetorByUsuarioUseCase;
        public readonly IGetSetorByIdUseCase _GetSetorByIdUseCase;
        public readonly IInsertSetorUseCase _IInsertSetorUseCase;

        public SetorController(IGetAllSetorUseCase getAllSetorUseCase, IActionResultConverter actionResultConverter, IGetSetorByEmpresaUseCase getSetorByEmpresaUseCase, IGetSetorByFuncionarioUseCase getSetorByFuncionarioUseCase, IGetSetorByUsuarioUseCase getSetorByUsuarioUseCase, IGetSetorByIdUseCase getSetorByIdUseCase, IInsertSetorUseCase iInsertSetorUseCase)
        {
            _GetAllSetorUseCase = getAllSetorUseCase;
            _ActionResultConverter = actionResultConverter;
            _GetSetorByEmpresaUseCase = getSetorByEmpresaUseCase;
            _GetSetorByFuncionarioUseCase = getSetorByFuncionarioUseCase;
            _GetSetorByUsuarioUseCase = getSetorByUsuarioUseCase;
            _GetSetorByIdUseCase = getSetorByIdUseCase;
            _IInsertSetorUseCase = iInsertSetorUseCase;
        }

        [ProducesResponseType(typeof(SetorDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdSetorByEmpresa")]

        public async Task<IActionResult> GetSetorByEmpresaId(int IdSetorByEmpresa)
        {
            var result = await _GetSetorByEmpresaUseCase.Execute(IdSetorByEmpresa);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(SetorDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdSetorByFuncionario")]

        public async Task<IActionResult> GetSetorFuncionarioId(int IdSetorByFuncionario)
        {
            var result = await _GetSetorByFuncionarioUseCase.Execute(IdSetorByFuncionario);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(SetorDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdSetorByUsuario")]

        public async Task<IActionResult> GetSetorByUsuarioId(int IdSetorByUsuario)
        {
            var result = await _GetSetorByUsuarioUseCase.Execute(IdSetorByUsuario);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(List<SetorDTO>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetAllSetor()
        {
            var result = await _GetAllSetorUseCase.Execute();
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(SetorDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> InsertSetor(SetorDTO response)
        {
            var result = await _IInsertSetorUseCase.Execute(response);
            return _ActionResultConverter.Convert(result);
        }
    }
}
