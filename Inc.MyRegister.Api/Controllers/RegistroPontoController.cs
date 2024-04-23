using Inc.MyRegister.Api.Interfaces;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.RegistroPontos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyRegister.Api.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class RegistroPontoController : ControllerBase
    {
        public readonly IGetRegistroPontoAllUseCase _GetRegistroPontoAllUseCase;
        public readonly IActionResultConverter _ActionResultConverter;
        public readonly IGetRegistroPontoByEmpresaUseCase _GetRegistroPontoByEmpresaUseCase;
        public readonly IGetRegistroPontoByFuncionarioUseCase _GetRegistroPontoByFuncionarioUseCase;
        public readonly IGetRegistroPontosUseCaseById _GetRegistroPontoByIdUseCase;
        public readonly IInsertRegistroPontoUseCase _InsertRegistroPontoUseCase;
        public readonly IUpdateRegistroPontoUseCase _UpdateRegistroPontoUseCase;

        public RegistroPontoController(IGetRegistroPontoAllUseCase getRegistroPontoAllUseCase, IActionResultConverter actionResultConverter, IGetRegistroPontoByEmpresaUseCase getRegistroPontoByNameUseCase, IGetRegistroPontoByFuncionarioUseCase getRegistroPontoByFuncionarioUseCase, IGetRegistroPontosUseCaseById getRegistroPontoByIdUseCase, IInsertRegistroPontoUseCase insertRegistroPontoUseCase, IUpdateRegistroPontoUseCase updateRegistroPontoUseCase)
        {
            _GetRegistroPontoAllUseCase = getRegistroPontoAllUseCase;
            _ActionResultConverter = actionResultConverter;
            _GetRegistroPontoByEmpresaUseCase = getRegistroPontoByNameUseCase;
            _GetRegistroPontoByFuncionarioUseCase = getRegistroPontoByFuncionarioUseCase;
            _GetRegistroPontoByIdUseCase = getRegistroPontoByIdUseCase;
            _InsertRegistroPontoUseCase = insertRegistroPontoUseCase;
            _UpdateRegistroPontoUseCase = updateRegistroPontoUseCase;
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdRegistroPonto")]

        public async Task<IActionResult> GetRegistroPontoById(int IdRegistroPonto)
        {
            var result = await _GetRegistroPontoByIdUseCase.Execute(IdRegistroPonto);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdRegistroPontoByFuncionario")]

        public async Task<IActionResult> GetRegistroPontoByIdFuncionario(int IdRegistroPontoByFuncionario)
        {
            var result = await _GetRegistroPontoByFuncionarioUseCase.Execute(IdRegistroPontoByFuncionario);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdRegistroPontoByEmpresa")]

        public async Task<IActionResult> GetRegistroPontoByIdEmpresa(int IdRegistroPontoByFuncionario)
        {
            var result = await _GetRegistroPontoByEmpresaUseCase.Execute(IdRegistroPontoByFuncionario);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetRegistroPontoAll()
        {
            var result = await _GetRegistroPontoAllUseCase.Execute();
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> InsertRegistroPonto(RegistroPontoDTO response)
        {
            var result = await _InsertRegistroPontoUseCase.Execute(response);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(RegistroPontoDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPut]

        public async Task<IActionResult> UpdateRegistroPonto(RegistroPontoDTO response)
        {
            var result = await _UpdateRegistroPontoUseCase.Execute(response);
            return _ActionResultConverter.Convert(result);
        }
    }
}
